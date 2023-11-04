using AutoMapper;

using BussienesLayer.DTO.Compound;
using BussienesLayer.DTO.LandmarkDTO;
using BussienesLayer.DTO.LandMarksCompoundDTO;
using BussienesLayer.DTO.ReviewDTO;
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

            //Salah
            CreateMap<ServicesCompound, DTOServicesCompound>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.services.Name))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.services.Description));
            CreateMap<DTOServicesCompound, ServicesCompound>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceBuilding, DTOServicesBuilding>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.service.Name))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.service.Description));
            CreateMap<DTOServicesBuilding, ServiceBuilding>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceUnit, DTOServicesUnit>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.service.Name))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.service.Description));
            CreateMap<DTOServicesUnit, ServiceUnit>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore());
                 
                 //Amr
     
         CreateMap<LandMarksCompound, LandMarksCompound_IncludeLandmarks_IncludeCompoundDTO>()
                .ForMember(dest => dest.landmark, opt => opt.MapFrom(src => src.landmark != null ? new LandmarkOperationsDTO { Name = src.landmark.Name } : null))
                .ForMember(dest => dest.compound, opt => opt.MapFrom(src => src.compound != null ? new CompoundOperationsDTO 
                { 
                   Id=src.compound.Id,
                   Name = src.compound.Name,
                   Description = src.compound.Description,
                   Address=src.compound.Address,
                   Latitude=src.compound.Latitude,
                   Longitude=src.compound.Longitude,
                   DateAdded=src.compound.DateAdded,
                   File=src.compound.File,
                   Street_area=src.compound.Street_area,
                   GreenArea=src.compound.GreenArea,
                   BuildingArea=src.compound.BuildingArea
                } : null));

         CreateMap<Review, Review_IncludeUserDTO>()
            .ForMember(dest => dest.FullName,
            opt => opt.MapFrom(src => src.user.FName!=null ? src.user.FName+src.user.LName : null));



      }

   }
}
        }
    }
}

