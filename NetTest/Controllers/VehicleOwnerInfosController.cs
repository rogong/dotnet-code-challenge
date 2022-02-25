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
    public class VehicleOwnerInfosController : BaseApiController
    {
        public IMapper _mapper ;
        private readonly DocumentService _documentService;

        private readonly StoreContext _context;
        public VehicleOwnerInfosController(StoreContext context, IMapper mapper, DocumentService documentService)
        {
            _documentService = documentService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarOwnerInfo>>> GetVehicleOwnerInfos()
        {
            return await _context.CarOwnerInfos.ToListAsync();
        }
         
        [HttpGet("{id}", Name = "GetVehicleOwnerInfo")]
        public async Task<ActionResult<CarOwnerInfo>> GetVehicleOwnerInfo(int id)
        {
            var carOwnerInfo = await _context.CarOwnerInfos.FindAsync(id);

            if(carOwnerInfo == null) return NotFound();

            return carOwnerInfo;
        }

        [HttpPost]
        public async Task<ActionResult<CarOwnerInfo>> CreateCarOwnerInfo(CreateCarOwnerInfoDto carOwnerInfoDto)
        {
            var carOwnerInfo = _mapper.Map<CarOwnerInfo>(carOwnerInfoDto);

            if (carOwnerInfo.Address == null || carOwnerInfo.FirstName == null || carOwnerInfo.LastName == null || carOwnerInfo.State == null || carOwnerInfo.Lga == null)
                return BadRequest(new ProblemDetails { Title = "Empty data" });

            if (carOwnerInfoDto.VehicleDocUrl != null && carOwnerInfoDto.PurchaseReceiptUrl != null)
            {
                var docResult = await _documentService.AddDocAsync(carOwnerInfoDto.VehicleDocUrl);
                // var docResult2 = await _documentService.AddDocAsync(carOwnerInfoDto.PurchaseReceiptUrl);

                if(docResult.Error != null)
                    return BadRequest(new ProblemDetails{Title = docResult.Error.Message});

                carOwnerInfo.VehicleDocUrl = docResult.SecureUrl.ToString();
                carOwnerInfo.PublicId = docResult.PublicId;

                 var docResult2 = await _documentService.AddDocAsync(carOwnerInfoDto.PurchaseReceiptUrl);

                if(docResult2.Error != null)
                    return BadRequest(new ProblemDetails{Title = docResult2.Error.Message});

                carOwnerInfo.PurchaseReceiptUrl = docResult2.SecureUrl.ToString();
                carOwnerInfo.PublicId = docResult2.PublicId;



            }
            _context.CarOwnerInfos.Add(carOwnerInfo);

            var result = await _context.SaveChangesAsync() > 0;

            if(result) return CreatedAtRoute("GetVehicleOwnerInfo", new {Id = carOwnerInfo.Id}, carOwnerInfo);

             return BadRequest(new ProblemDetails { Title = "Problem creating new car owner info" });
        }

      


    }
}