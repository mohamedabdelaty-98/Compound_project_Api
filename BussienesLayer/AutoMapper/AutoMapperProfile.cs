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


           
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            CreateMap<CompoundImage, DTOCompoundImage>();
            CreateMap<BuildingImage, DTOBuildingImage>();
            CreateMap<UnitImage, DTOUnitImage>();

            CreateMap<DTOCompoundImage, CompoundImage>();
            CreateMap<DTOBuildingImage, BuildingImage>();
            CreateMap<DTOUnitImage, UnitImage>();




            CreateMap<DTOUnitComponent, UnitComponent>()
                .ForPath(dest => dest.component.Name, opt => opt.Ignore());


            CreateMap<DTOUnit, Unit>()
           .ForMember(dest => dest.status, opt => opt.MapFrom(src => Enum.Parse(typeof(Status), src.status)))
           .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BulidingNumber))
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


        }
    }
}
