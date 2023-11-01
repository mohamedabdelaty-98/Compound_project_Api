using AutoMapper;
using BussienesLayer.DTO.Compound;
using BussienesLayer.DTO.LandmarkDTO;
using BussienesLayer.DTO.LandMarksCompoundDTO;
using BussienesLayer.DTO.ReviewDTO;
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