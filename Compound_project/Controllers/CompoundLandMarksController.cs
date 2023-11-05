using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandmarkReposatory;
using DataAccessLayer.Reposatories.LandMarksCompoundReposatory;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundLandMarksController : ControllerBase
    {
        private readonly ILandMarksCompoundReposatory _landmarkcompound;
        private readonly ILandmarkReposatory _landmark;
        private readonly IMapper _mapper;

        public CompoundLandMarksController(ILandMarksCompoundReposatory _landmarkcompound,
            ILandmarkReposatory _landmark,IMapper _mapper)
        {
            this._landmarkcompound = _landmarkcompound;
            this._landmark = _landmark;
            this._mapper = _mapper;
        }
        [HttpGet("GetLandmarkCompoundByCompound/{id}")]
        public ActionResult<DTOResult> GetLandmarkCompoundByCompound(int id)
        {
            List<LandMarksCompound> landMarksCompounds = _landmarkcompound.GetCompoundlandmarks(id);
            List<DTOLandMarksCompound> dTOLandMarksCompounds =
                landMarksCompounds.Select(item => _mapper.Map<DTOLandMarksCompound>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dTOLandMarksCompounds.Count != 0 ? true : false;
            result.Data = dTOLandMarksCompounds;
            return result;
        }

        [HttpGet("GetLandmarkCompound/{id}")]
        public ActionResult<DTOResult> GetLandmarkCompound(int id)
        {
            DTOResult result = new DTOResult();
            LandMarksCompound landMarksCompound = _landmarkcompound.GetById(id);
            DTOLandMarksCompound dTOLandMarksCompound = _mapper.Map<DTOLandMarksCompound>(landMarksCompound);
            result.IsPass = dTOLandMarksCompound != null ? true : false;
            result.Data = dTOLandMarksCompound;
            return result;
        }

        [HttpPost("Insertcompoundlandmark")]
        public ActionResult<DTOResult> Insertcompoundlandmark(DTOLandMarksCompound dTOLandMarksCompound)
        {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                try
                {

                    Landmark landmark = _landmark.GetLandmarkByName(dTOLandMarksCompound.Name);
                    if (landmark == null)
                    {
                        landmark = new Landmark() { Name = dTOLandMarksCompound.Name };
                        _landmark.insert(landmark);
                        _landmark.save();
                        dTOLandMarksCompound.LandMarkId = landmark.Id;
                    }
                    else
                        dTOLandMarksCompound.LandMarkId = landmark.Id;

                    LandMarksCompound landMarksCompound = _mapper.Map<LandMarksCompound>(dTOLandMarksCompound);
                    _landmarkcompound.insert(landMarksCompound);
                    _landmarkcompound.save();
                    result.IsPass = true;
                    result.Data = $"Created LandMarkCompound with ID {landMarksCompound.Id}";
                }
                catch (Exception ex)
                {

                    result.IsPass = false;
                    result.Data = $"An error occurred while creating the LandMark Compound.";
                }


            }
            else
            {
                result.IsPass = false;
                result.Data = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            }

            return result;
        }
        [HttpPut("EditcompoundLandmark/{id}")]
        public ActionResult<DTOResult> EditcompoundLandmark(int id, DTOLandMarksCompound dTOLandMarksCompound)
        {
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {
                    Landmark landmark = _landmark.GetLandmarkByName(dTOLandMarksCompound.Name);
                    if (landmark == null)
                    {
                        landmark = new Landmark() { Name = dTOLandMarksCompound.Name };
                        _landmark.insert(landmark);
                        _landmark.save();
                        dTOLandMarksCompound.LandMarkId = landmark.Id;
                    }
                    else
                        dTOLandMarksCompound.LandMarkId = landmark.Id;
                    LandMarksCompound landMarksCompound = _landmarkcompound.GetById(id);
                    if (landMarksCompound != null)
                    {
                        _mapper.Map(dTOLandMarksCompound, landMarksCompound);
                        _landmarkcompound.update(landMarksCompound);
                        _landmarkcompound.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "landmark Compound Not Found";
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
                result.Data = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            }
            return result;
        }

        [HttpDelete("DeleteLandMarkCompound/{id}")]
        public ActionResult<DTOResult> DeleteLandMarkCompound(int id)
        {
            DTOResult result = new DTOResult();
            LandMarksCompound landMarksCompound = _landmarkcompound.GetById(id);
            if (landMarksCompound != null)
            {
                _landmarkcompound.Delete(id);
                _landmarkcompound.save();
                result.IsPass = true;
                result.Data = "Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "LandMarksCompound Not Found";
            }
            return result;
        }
    }
}
