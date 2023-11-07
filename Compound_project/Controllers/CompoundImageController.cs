using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Reposatories;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundImageController : ControllerBase
    {
        private readonly ICompoundImage _compoundImage;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CompoundImageController(ICompoundImage compoundImage,IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            this._compoundImage = compoundImage;
            this._mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("GetCompoundImages/{CompoundId}")]
        public ActionResult<DTOResult> GetCompoundImages(int CompoundId)
        {

            List<byte[]> imageslist = new List<byte[]>();
            var result = new DTOResult();
            List<CompoundImage> compoundImages = _compoundImage.GetCompoundImages(CompoundId);
            List<DTOCompoundImage> dTOCompoundImages = compoundImages.Select(item => _mapper.Map<DTOCompoundImage>(item)).ToList();

            if (compoundImages == null || compoundImages.Count == 0)
            {
                result.IsPass = false;
                result.Data = "No Images Founded";
            }
            else
            {
                result.IsPass = true;
                foreach (var compoundimage in dTOCompoundImages)
                {

                    var fullpath = _hostingEnvironment.ContentRootPath + compoundimage.ImageUrl;
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
        public ActionResult<DTOResult> GetAllImages()
        {
            List<CompoundImage> compoundImages = _compoundImage.GetAll();
            List<DTOCompoundImage> dTOCompoundImages = compoundImages.Select(item => _mapper.Map<DTOCompoundImage>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dTOCompoundImages.Count != 0 ? true : false;
            result.Data = dTOCompoundImages;
            return result;
        }

        [HttpGet("GetById/{Id}")]
        public ActionResult<DTOResult> GetById(int Id)
        {
            CompoundImage compoundImage = _compoundImage.GetById(Id);
            DTOCompoundImage dTOCompoundImage = _mapper.Map<DTOCompoundImage>(compoundImage);
            DTOResult result = new DTOResult();
            result.IsPass = dTOCompoundImage != null ? true : false;
            result.Data = dTOCompoundImage;
            return result;
        }

        [HttpPost("AddCompoundImage")]
        public ActionResult<DTOResult> AddCompoundImage(DTOCompoundImage dTOCompoundImage)
        {

            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {
                    CompoundImage compoundImage = _mapper.Map<CompoundImage>(dTOCompoundImage);
                    _compoundImage.insert(compoundImage);
                    _compoundImage.save();
                    result.IsPass = true;
                    result.Data = $"Created compoundimage with ID {compoundImage.Id}";
                }
                catch(Exception ex)
                {
                    result.IsPass = false;
                    result.Data = "An error occurred while Adding the compoundimage.";
                }
            }
            else
            {
                result.IsPass = false;
                result.Data = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            return result;
        }
        [HttpPut("EditCompoundImage")]
        public ActionResult<DTOResult> EditCompoundImage(DTOCompoundImage dTOCompoundImage)
        {
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {
                    CompoundImage compoundImage = _compoundImage.GetById(dTOCompoundImage.Id);
                    if (compoundImage != null)
                    {
                        _mapper.Map(dTOCompoundImage, compoundImage);
                        _compoundImage.update(compoundImage);
                        _compoundImage.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "CompoundImage not found";
                    }
                }catch(Exception ex)
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
        [HttpDelete("DeleteCompoundImage")]
        public ActionResult<DTOResult> DeleteCompoundImage(int id)
        {
            DTOResult result = new DTOResult();
            CompoundImage compoundImage = _compoundImage.GetById(id);
            if (compoundImage != null)
            {
                _compoundImage.Delete(id);
                _compoundImage.save();
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
