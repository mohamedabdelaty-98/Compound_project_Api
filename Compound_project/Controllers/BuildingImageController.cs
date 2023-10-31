using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Reposatories;
using DataAccessLayer.Models;
using AutoMapper;
using BussienesLayer.DTO;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingImageController : ControllerBase
    {
        private readonly IBuildingImage _buildingImage;
        private readonly IMapper _mapper;
        public BuildingImageController(IBuildingImage buildingImage, IMapper mapper)
        {
            this._buildingImage = buildingImage;
            this._mapper = mapper;
        }

        [HttpGet("GetAllImages")]
        public ActionResult<DTOResult> GetAllImages() {
            List<BuildingImage> buildingImages = _buildingImage.GetAll();
            // List<DTOUnit> dTOUnits= units.Select(item => _mapper.Map<DTOUnit>(item)).ToList();

            List<DTOBuildingImage> dTOBuildingImages = buildingImages.Select(item => _mapper.Map<DTOBuildingImage>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dTOBuildingImages.Count != 0 ? true : false;
            result.Data = dTOBuildingImages;
            return result;
        }

        [HttpGet("GetById/{Id}")]
        public ActionResult<DTOResult> GetById(int Id)
        {
            DTOResult result = new DTOResult();
            BuildingImage buildingImage = _buildingImage.GetById(Id);
            if(buildingImage!=null)
            {
                DTOBuildingImage dTOBuildingImage = _mapper.Map<DTOBuildingImage>(buildingImage);
                result.IsPass = true;
                result.Data = dTOBuildingImage;

            }
            else
            {
                result.IsPass=false;
                result.Data = "Building Image not found";
            }
            return result;
        }

        [HttpPost("AddBuildingImage")]
        public ActionResult<DTOResult> AddBuildingImage(DTOBuildingImage dtobuildingImage) {

            
            BuildingImage buildingImage = _mapper.Map<BuildingImage>(dtobuildingImage);
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {
                    result.IsPass = true;
                    result.Data = $"Added BuildingImage with ID {buildingImage.Id}";
                    _buildingImage.insert(buildingImage);
                    _buildingImage.save();
                }
                catch (Exception ex)
                {
                    result.IsPass = false;
                    result.Data = "An error occurred while Adding the buildingimage.";
                }
                
            }
            else
            {
                result.IsPass = false;
                result.Data = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            return result;
        }
        [HttpDelete("DeleteBuildingImage")]
        public ActionResult<DTOResult> DeleteBuildingImage(int id)
        {
            DTOResult result = new DTOResult();
            BuildingImage buildingImage = _buildingImage.GetById(id);
            if (buildingImage != null)
            {
                _buildingImage.Delete(id);
                _buildingImage.save();
                result.IsPass = true;
                result.Data = "Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Not Found";
            }
            return result;
        }
        [HttpPut("EditBuildingImage")]
        public ActionResult<DTOResult> EditBuildingImage(DTOBuildingImage dtobuildingImage)
        {
            BuildingImage buildingimage = _buildingImage.GetById(dtobuildingImage.Id);
            DTOResult result = new DTOResult();
            if (buildingimage != null)
            {
                if (ModelState.IsValid)
                {
                    result.IsPass = true;
                    result.Data = dtobuildingImage;
                    // buildingimage = _mapper.Map<BuildingImage>(dtobuildingImage);
                    _mapper.Map(dtobuildingImage, buildingimage);
           
                    _buildingImage.update(buildingimage);
                    _buildingImage.save();
                }
                else
                {
                    result.IsPass = false;
                    result.Data = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                }

            }
            else
            {
                result.IsPass = false;
                result.Data = "Not Found";
            }
            return result;
        }

        [HttpGet("GetBuildingImages/{BuildingId}")]
        public ActionResult<DTOResult>GetBuildingImages(int BuildingId)
        {
            var result = new DTOResult();
            List<BuildingImage>buildingImages = _buildingImage.GetBuildingImages(BuildingId);
            List<DTOBuildingImage> dTOBuildingImages = buildingImages.Select(item => _mapper.Map<DTOBuildingImage>(item)).ToList();

            if (buildingImages == null || buildingImages.Count==0) {
                result.IsPass = false;
                result.Data = "No Images Founded";
            }
            else
            {
                result.IsPass= true;
                result.Data = dTOBuildingImages;
            }
            return result;

        }



    }
}

