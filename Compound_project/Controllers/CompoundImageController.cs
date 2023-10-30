using AutoMapper;
using BussienesLayer.DTO;
using BussienesLayer.Reposatories;
using Compound_project.DTO;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundImageController : ControllerBase
    {
        private readonly ICompoundImage _compoundImage;
        private readonly IMapper _mapper;
        public CompoundImageController(ICompoundImage compoundImage,IMapper mapper)
        {
            this._compoundImage = compoundImage;
            this._mapper = mapper;
        }

        [HttpGet("GetAllImages")]
        public ActionResult<DTOResult> GetAllImages()
        {
            List<CompoundImage> compoundImages = _compoundImage.GetAll();
            // List<DTOUnit> dTOUnits= units.Select(item => _mapper.Map<DTOUnit>(item)).ToList();

            List<DTOCompoundImage> dTOCompoundImages = compoundImages.Select(item => _mapper.Map<DTOCompoundImage>(item)).ToList();
            DTOResult result = new DTOResult();
            if (dTOCompoundImages == null || dTOCompoundImages.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = dTOCompoundImages;
            return result;
        }

        [HttpGet("GetById/{Id}")]
        public ActionResult<DTOResult> GetById(int Id)
        {
            CompoundImage compoundImage = _compoundImage.GetById(Id);
            DTOCompoundImage dTOCompoundImage = _mapper.Map<DTOCompoundImage>(compoundImage);
            DTOResult result = new DTOResult();
            if (dTOCompoundImage == null) result.IsPass = false;
            else result.IsPass = true;
            result.Data = dTOCompoundImage;
            return result;
        }

        [HttpPost("AddCompoundImage")]
        public ActionResult<DTOResult> AddCompoundImage(DTOCompoundImage dTOCompoundImage)
        {

            CompoundImage compoundImage = new CompoundImage();
            compoundImage = _mapper.Map<CompoundImage>(dTOCompoundImage);
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                result.IsPass = true;
                result.Data = dTOCompoundImage;
                _compoundImage.insert(compoundImage);
                _compoundImage.save();
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
        [HttpPut("EditCompoundImage")]
        public ActionResult<DTOResult> EditCompoundImage(DTOCompoundImage dTOCompoundImage)
        {
            CompoundImage compoundImage = _compoundImage.GetById(dTOCompoundImage.Id);
            DTOResult result = new DTOResult();
            if (compoundImage != null)
            {
                if (ModelState.IsValid)
                {
                    result.IsPass = true;
                    result.Data = dTOCompoundImage;
                    _mapper.Map(dTOCompoundImage, compoundImage);

                    _compoundImage.update(compoundImage);
                    _compoundImage.save();
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

        [HttpGet("GetCompoundImages/{CompoundId}")]
        public ActionResult<DTOResult> GetCompoundImages(int CompoundId)
        {
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
                result.Data = dTOCompoundImages;
            }
            return result;

        }
    }
}
