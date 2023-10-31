using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;

namespace BussienesLayer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Unit, DTOUnit>()
          .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status.ToString()))
          .ForMember(dest => dest.BulidingNumber, opt => opt.MapFrom(src => src.building != null ? src.building.BulidingNumber : default));

            CreateMap<DTOUnit, Unit>()
         .ForMember(dest => dest.status, opt => opt.MapFrom(src => Enum.Parse(typeof(Status), src.status)))
         .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BulidingNumber))
         .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UnitComponent, DTOUnitComponent>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.component.Name));

            CreateMap<DTOUnitComponent, UnitComponent>()
                .ForPath(dest => dest.component.Name, opt => opt.Ignore());

            CreateMap<CComponent, DTOComponent>();

            //Shrouk
            CreateMap<CompoundImage, DTOCompoundImage>();
            CreateMap<BuildingImage, DTOBuildingImage>();
            CreateMap<UnitImage, DTOUnitImage>();

            CreateMap<DTOCompoundImage, CompoundImage>();
            CreateMap<DTOBuildingImage, BuildingImage>();
            CreateMap<DTOUnitImage, UnitImage>();

            //Men3m
            CreateMap<Compound, DTOCompound>();
            CreateMap<DTOCompound, Compound>();

            //Raghad
            CreateMap<Building, DTOBuilding>()
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status.ToString()));
            CreateMap<DTOBuilding, Building>()
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => Enum.Parse(typeof(Status), src.status)));

            //Zaki
            CreateMap<Application, DTOApplication>();
            CreateMap<DTOApplication, Application>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
           













            CreateMap<ServiceUnit, DTOServicesUnit>();
            CreateMap<DTOServicesUnit, ServiceUnit>();

            CreateMap<Service, DTOServices>();
            CreateMap<DTOServices, Service>();

            CreateMap<ServiceBuilding, DTOServicesBuilding>();
            CreateMap<DTOServicesBuilding, ServiceBuilding>();

            CreateMap<ServicesCompound, DTOServicesCompound>();
            CreateMap<DTOServicesCompound, ServicesCompound>();


            CreateMap<Compound, DTOCompound>();
            CreateMap<DTOCompound, Compound>();



            CreateMap<Building, DTOBuilding>()
                .ForMember(dest => dest.status, opt=> opt.MapFrom(src=>src.status.ToString()));

            CreateMap<DTOBuilding, Building>()
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => Enum.Parse(typeof(Status), src.status)));

        }
    }
}
