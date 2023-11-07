using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ImageController : ControllerBase
    {
        private readonly ICompoundImage _compoundImage;
        private readonly IUnitImage _unitImage;
        private readonly IBuildingImage _buildingImage;
        private readonly IMapper _mapper;

        public ImageController(ICompoundImage compoundImage, IUnitImage unitImage, IBuildingImage buildingImage, IMapper mapper)
        {
            _compoundImage = compoundImage;
            _unitImage = unitImage;
            _buildingImage = buildingImage;
            _mapper = mapper;
            
        }

        [HttpPost("UploadUnitImage/{Id}")]
        public async Task <ActionResult<DTOResult>> UploadUnitImage(IFormFile file,int Id)//dtounitimage,buildingimage,
        {
            UnitImage unitImage = new UnitImage();
            unitImage.UnitId = Id; 
            DTOResult result = new DTOResult();
            if(file == null|| file.Length == 0)
            {
                result.IsPass = false;
                result.Data = "No Images Uploaded";
            }
            try
            {
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                var FileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(uploadDir, FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                //store uploaded file to the database
              
                var imageUrl = $"/Uploads/{FileName}";
                unitImage.ImageUrl = imageUrl;
                _unitImage.insert(unitImage);
                _unitImage.save();
                result.IsPass = true;
                result.Data = "File Uploaded Successfully";
                return result;
            }
            catch (Exception ex)
            {
                result.IsPass = false;
                result.Data = "An error occurred while processing the file";
                return result;
            }
        }

        [HttpPost("UploadBuildingImage/{Id}")]
        public async Task<ActionResult<DTOResult>> UploadBuildingImage(IFormFile file, int Id)
        {
            BuildingImage buildingImage = new BuildingImage();
            buildingImage.BuildingId = Id;
            DTOResult result = new DTOResult();
            if (file == null || file.Length == 0)
            {
                result.IsPass = false;
                result.Data = "No Images Uploaded";
            }
            try
            {
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                var FileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(uploadDir, FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                //store uploaded file to the database
                var imageUrl = $"/Uploads/{FileName}";
                buildingImage.ImageUrl = imageUrl;
                _buildingImage.insert(buildingImage);
                _buildingImage.save();
                result.IsPass = true;
                result.Data = "File Uploaded Successfully";
                return result;
            }
            catch (Exception ex)
            {
                result.IsPass = false;
                result.Data = "An error occurred while processing the file";
                return result;
            }
        }

        [HttpPost("UploadCompoundImage/{Id}")]
        public async Task<ActionResult<DTOResult>> UploadCompoundImage(IFormFile file, int Id)
        {
            CompoundImage compoundImage = new CompoundImage();
             compoundImage.CompoundId= Id;
            DTOResult result = new DTOResult();
            if (file == null || file.Length == 0)
            {
                result.IsPass = false;
                result.Data = "No Images Uploaded";
            }
            try
            {
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                var FileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(uploadDir, FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                //store uploaded file to the database

                var imageUrl = $"/Uploads/{FileName}";
                compoundImage.ImageUrl = imageUrl;
                _compoundImage.insert(compoundImage);
                _compoundImage.save();
                result.IsPass = true;
                result.Data = "File Uploaded Successfully";
                return result;
            }
            catch (Exception ex)
            {
                result.IsPass = false;
                result.Data = "An error occurred while processing the file";
                return result;
            }
        }

    }
       
}

