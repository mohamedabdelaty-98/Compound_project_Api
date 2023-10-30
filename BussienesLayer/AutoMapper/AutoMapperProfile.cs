using AutoMapper;
using BussienesLayer.DTO;
using Compound_project.DTO;
using DataAccessLayer.Models;

namespace Compound_project.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Unit, DTOUnit>()
          .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status.ToString()))
          .ForMember(dest => dest.BulidingNumber, opt => opt.MapFrom(src => src.building != null ? src.building.BulidingNumber : default));

            CreateMap<UnitComponent, DTOUnitComponent>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.component.Name));

            CreateMap<Building, DTOBuilding>()
                .ForMember(dest => dest.status, opt=> opt.MapFrom(src=>src.status.ToString()));

            CreateMap<DTOBuilding, Building>()
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => Enum.Parse(typeof(Status), src.status)));

        }
    }
}
