using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Reposatories.LandmarkReposatory;
using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
   public class LandmarkController : ControllerBase
   {
      private readonly ILandmarkReposatory _landmark;
        private readonly IMapper _mapper;

        public LandmarkController(ILandmarkReposatory _landmark,IMapper _mapper)
        {
         this._landmark = _landmark;
            this._mapper = _mapper;
        }

        [HttpGet("GetAll")]
        public ActionResult<DTOResult> GetAll()
        {
            List<Landmark> landmarks = _landmark.GetAll();
            List<DTOLandmark> dTOLandmark =
               landmarks.Select(item => _mapper.Map<DTOLandmark>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dTOLandmark.Count != 0 ? true : false;
            result.Data = dTOLandmark;
            return result;
        }
        [HttpDelete("DeleteLandmark/{id}")]
        public ActionResult<DTOResult> DeleteLandmark(int id)
        {
            DTOResult result = new DTOResult();
            Landmark landmark = _landmark.GetById(id);
            if (landmark != null)
            {
                _landmark.Delete(id);
                _landmark.save();
                result.IsPass = true;
                result.Data = "Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Landmark Not Found ";
            }
            return result;
        }



    }
}
