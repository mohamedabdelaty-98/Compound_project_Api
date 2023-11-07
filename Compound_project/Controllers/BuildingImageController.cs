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
        private readonly IWebHostEnvironment _hostingEnvironment;
        public BuildingImageController(IBuildingImage buildingImage, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            this._buildingImage = buildingImage;
            this._mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("GetBuildingImages/{BuildingId}")]
        public ActionResult<DTOResult> GetBuildingImages(int BuildingId)
        {

            List<byte[]> imageslist = new List<byte[]>();
            var result = new DTOResult();
            List<BuildingImage> buildingImages = _buildingImage.GetBuildingImages(BuildingId);
            List<DTOBuildingImage> dTOBuildingImages = buildingImages.Select(item => _mapper.Map<DTOBuildingImage>(item)).ToList();

            if (buildingImages == null || buildingImages.Count == 0)
            {
                result.IsPass = false;
                result.Data = "No Images Founded";
            }
            else
            {
                result.IsPass = true;
                foreach (var buildingImage in dTOBuildingImages)
                {

                    var fullpath = _hostingEnvironment.ContentRootPath+ buildingImage.ImageUrl;
                    if (System.IO.File.Exists(fullpath))
                    {
                        // Read the file into a byte array.
                        byte[] imageData = System.IO.File.ReadAllBytes(fullpath);
                        imageslist.Add(imageData);
                    }

                }
                result.Data = imageslist;
            }
            return result;
        }
        [HttpGet("GetAllImages")]
        public ActionResult<DTOResult> GetAllImages() {
            List<BuildingImage> buildingImages = _buildingImage.GetAll();
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
            DTOBuildingImage dTOBuildingImage = _mapper.Map<DTOBuildingImage>(buildingImage);
            result.IsPass = dTOBuildingImage != null ? true : false;
            result.Data = dTOBuildingImage;
            return result;
        }

        [HttpPost("AddBuildingImage")]
        public ActionResult<DTOResult> AddBuildingImage(DTOBuildingImage dtobuildingImage) {

            
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {
                    BuildingImage buildingImage = _mapper.Map<BuildingImage>(dtobuildingImage);
                    _buildingImage.insert(buildingImage);
                    _buildingImage.save();
                    result.IsPass = true;
                    result.Data = $"Added BuildingImage with ID {buildingImage.Id}";
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
     
        [HttpPut("EditBuildingImage")]
        public ActionResult<DTOResult> EditBuildingImage(DTOBuildingImage dtobuildingImage)
        {
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {
                    BuildingImage buildingimage = _buildingImage.GetById(dtobuildingImage.Id);
                    if (buildingimage != null)
                    {
                        _mapper.Map(dtobuildingImage, buildingimage);
                        _buildingImage.update(buildingimage);
                        _buildingImage.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "BuildingImage not found";
                    }
                }
                catch (Exception ex)
                {
                    result.IsPass = false;
                    result.Data = "An error occurred during update ";
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
    }
}

