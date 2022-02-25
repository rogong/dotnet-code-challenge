using AutoMapper;
using NetTest.DTOs;
using NetTest.Entities;

namespace NetTest.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCarOwnerInfoDto, CarOwnerInfo>();
            CreateMap<CreateFuellingStationInfoDto, FuellingStation>();
        }
    }
}