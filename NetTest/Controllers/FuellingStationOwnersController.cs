

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTest.Data;
using NetTest.DTOs;
using NetTest.Entities;
using NetTest.Services;

namespace NetTest.Controllers
{
    public class FuellingStationOwnerController : BaseApiController
    {
        public IMapper _mapper ;
        private readonly DocumentService _documentService;

        private readonly StoreContext _context;
        public FuellingStationOwnerController(StoreContext context, IMapper mapper, DocumentService documentService)
        {
            _documentService = documentService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FuellingStation>>> GetFuellingStationInfos()
        {
            return await _context.FuellingStations.ToListAsync();
        }
         
        [HttpGet("{id}", Name = "GetFuellingStationInfo")]
        public async Task<ActionResult<FuellingStation>> GetFuellingStationInfo(int id)
        {
            var fuellingStation = await _context.FuellingStations.FindAsync(id);

            if(fuellingStation == null) return NotFound();

            return fuellingStation;
        }

        [HttpPost]
        public async Task<ActionResult<FuellingStation>> CreateFuellingStationInfo(CreateFuellingStationInfoDto fuellingStationInfoDto)
        {
            var fuellingStationInfo= _mapper.Map<FuellingStation>(fuellingStationInfoDto);

            if (fuellingStationInfo.Address == null || fuellingStationInfo.OwnersName == null 
             || fuellingStationInfo.State == null || fuellingStationInfo.Lga == null)
                return BadRequest(new ProblemDetails { Title = "Empty data" });

            if (fuellingStationInfoDto.BusinessDocUrl != null && fuellingStationInfoDto.DepotReceiptUrl != null)
            {
                var docResult = await _documentService.AddDocAsync(fuellingStationInfoDto.BusinessDocUrl);
                // var docResult2 = await _documentService.AddDocAsync(fuellingStationInfoDto.PurchaseReceiptUrl);

                if(docResult.Error != null)
                    return BadRequest(new ProblemDetails{Title = docResult.Error.Message});

                fuellingStationInfo.BusinessDocUrl= docResult.SecureUrl.ToString();
                fuellingStationInfo.PublicId = docResult.PublicId;

                 var docResult2 = await _documentService.AddDocAsync(fuellingStationInfoDto.DepotReceiptUrl);

                if(docResult2.Error != null)
                    return BadRequest(new ProblemDetails{Title = docResult2.Error.Message});

                fuellingStationInfo.DepotReceiptUrl= docResult2.SecureUrl.ToString();
                fuellingStationInfo.PublicId = docResult2.PublicId;



            }
            _context.FuellingStations.Add(fuellingStationInfo);

            var result = await _context.SaveChangesAsync() > 0;

            if(result) return CreatedAtRoute("GetFuellingStationInfo", new {Id = fuellingStationInfo.Id}, fuellingStationInfo);

             return BadRequest(new ProblemDetails { Title = "Problem creating new car owner info" });
        }

       
    }
}