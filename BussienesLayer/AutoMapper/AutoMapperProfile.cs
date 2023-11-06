using AutoMapper;
using BussienesLayer.DTO.ReviewDTO;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
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
            CreateMap<User, DTORegisterUser>();
            CreateMap<DTORegisterUser, User>().ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.gender.ToString()));



            CreateMap<DTOCompoundImage, CompoundImage>();
            CreateMap<DTOBuildingImage, BuildingImage>();
            CreateMap<DTOUnitImage, UnitImage>();

            //Men3m
            CreateMap<Compound, DTOCompound>()
                .ForMember(dest => dest.File, opt => opt.Ignore());
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

            //Salah
            CreateMap<Service, DTOServices>();
            CreateMap<ServicesCompound, DTOServicesCompound>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.services.Name))
                 .ForMember(dest => dest.IConName, opt => opt.MapFrom(src => src.services.IConName))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.services.Description));

            CreateMap<DTOServicesCompound, ServicesCompound>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceBuilding, DTOServicesBuilding>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.service.Name))
                 .ForMember(dest => dest.IConName, opt => opt.MapFrom(src => src.service.IConName))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.service.Description));
            CreateMap<DTOServicesBuilding, ServiceBuilding>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceUnit, DTOServicesUnit>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.service.Name))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.service.Description));
            CreateMap<DTOServicesUnit, ServiceUnit>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore());

            //Amr
            CreateMap<Landmark, DTOLandmark>();
            CreateMap<LandMarksCompound, DTOLandMarksCompound>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.landmark.Name));
            CreateMap<DTOLandMarksCompound, LandMarksCompound>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());


            CreateMap<Review, Review_IncludeUserDTO>()
            .ForMember(dest => dest.FullName,
            opt => opt.MapFrom(src => src.user.FName != null ? src.user.FName + src.user.LName : null));



        }


    }
}

