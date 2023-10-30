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
    public class UnitImageController : ControllerBase
    {
        private readonly IUnitImage _unitImage;
        private readonly IMapper _mapper;
        public UnitImageController(IUnitImage unitImage,IMapper mapper)
        {
            this._unitImage = unitImage;
            this._mapper = mapper;
        }
        [HttpGet("GetAllImages")]
        public ActionResult<DTOResult> GetAllImages()
        {
            List<UnitImage> unitImages = _unitImage.GetAll();
            // List<DTOUnit> dTOUnits= units.Select(item => _mapper.Map<DTOUnit>(item)).ToList();

            List<DTOUnitImage> dTOUintImages = unitImages.Select(item => _mapper.Map<DTOUnitImage>(item)).ToList();
            DTOResult result = new DTOResult();
            if (dTOUintImages == null || dTOUintImages.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = dTOUintImages;
            return result;
        }

        [HttpGet("GetById/{Id}")]
        public ActionResult<DTOResult> GetById(int Id)
        {
            UnitImage unitImage = _unitImage.GetById(Id);
            DTOUnitImage dTOUnitImage = _mapper.Map<DTOUnitImage>(unitImage);
            DTOResult result = new DTOResult();
            if (dTOUnitImage == null) result.IsPass = false;
            else result.IsPass = true;
            result.Data = dTOUnitImage;
            return result;
        }

        [HttpPost("AddUnitImage")]
        public ActionResult<DTOResult> AddUnitImage(DTOUnitImage dTOUnitImage)
        {

            UnitImage unitImage = new UnitImage();
            unitImage = _mapper.Map<UnitImage>(dTOUnitImage);
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                result.IsPass = true;
                result.Data = dTOUnitImage;
                _unitImage.insert(unitImage);
                _unitImage.save();
            }
            else
            {
                result.IsPass = false;
                result.Data = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            return result;
        }
        [HttpDelete("DeleteUnitImage")]
        public ActionResult<DTOResult> DeleteUnitImage(int id)
        {
            DTOResult result = new DTOResult();
            UnitImage unitImage = _unitImage.GetById(id);
            if (unitImage != null)
            {
                _unitImage.Delete(id);
                _unitImage.save();
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
        [HttpPut("EditUnitImage")]
        public ActionResult<DTOResult> EditUnitImage(DTOUnitImage dTOUnitImage)
        {
            UnitImage unitImage = _unitImage.GetById(dTOUnitImage.Id);
            DTOResult result = new DTOResult();
            if (unitImage != null)
            {
                if (ModelState.IsValid)
                {
                    result.IsPass = true;
                    result.Data = dTOUnitImage;
                  
                    _mapper.Map(dTOUnitImage, unitImage);

                    _unitImage.update(unitImage);
                    _unitImage.save();
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

        [HttpGet("GetUnitImages/{UnitId}")]
        public ActionResult<DTOResult> GetBuildingImages(int UnitId)
        {
            var result = new DTOResult();
            List<UnitImage> unitImages = _unitImage.GetUnitImages(UnitId);
            List<DTOUnitImage> dTOUnitImages = unitImages.Select(item => _mapper.Map<DTOUnitImage>(item)).ToList();

            if (unitImages == null || unitImages.Count == 0)
            {
                result.IsPass = false;
                result.Data = "No Images Founded";
            }
            else
            {
                result.IsPass = true;
                result.Data = dTOUnitImages;
            }
            return result;

        }
    }
}
