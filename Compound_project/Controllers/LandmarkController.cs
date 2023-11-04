using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Reposatories.LandmarkReposatory;
using Compound_project.Reposatories.Landmarks;
using BussienesLayer.DTO.LandmarkDTO;
using Compound_project.Reposatories.LandmarkReposatory;

namespace Compound_project.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class LandmarkController : ControllerBase
   {
      private readonly ILandmarkOperationsReposatory _LandmarkOperationsReposatory;
      public LandmarkController(ILandmarkOperationsReposatory _LandmarkOperationsReposatory)
      {
         this._LandmarkOperationsReposatory = _LandmarkOperationsReposatory;

      }
      
      [HttpGet]
      public IActionResult GetAll(IGetAllDTOReposatories _GetAllDTOReposatories)
      {
         return Ok(_GetAllDTOReposatories.GetAllDTO());
      }

      [HttpPost]
      public async Task<IActionResult> CreateLandmark(LandmarkOperationsDTO landmarkOperationsDTO)
      {
         LandmarkCreateReturn landmarkCreateReturn = await _LandmarkOperationsReposatory.Create(landmarkOperationsDTO);
         if(landmarkCreateReturn.Landmark!=null)
            return Created(landmarkCreateReturn.URL, new { landmarkCreateReturn.Landmark.Id, landmarkCreateReturn.Landmark.Name });
         return BadRequest();
      }

      [HttpPut("{id:int}")]
      public async Task<IActionResult> UpdateLandmark(int id, LandmarkOperationsDTO landmarkOperationsDTO, ILandmarkReposatory _LandmarkReposatory)
      {
         if (ModelState.IsValid == true)
         {
            bool FindLandmark = await _LandmarkOperationsReposatory.Update(id, landmarkOperationsDTO, _LandmarkReposatory);
            if (FindLandmark == true)
               return StatusCode(204, landmarkOperationsDTO);

            return BadRequest("Not Found Landmark");
         }
         return BadRequest("ModelState Not Valid");
      }
               

      [HttpDelete("{id:int}")]
      public async Task<IActionResult> DelteLandmark(int id, ILandmarkReposatory _LandmarkReposatory)
      {
        bool FindLandmark=  await _LandmarkOperationsReposatory.Delete(id, _LandmarkReposatory);
         if(FindLandmark == true)
            return StatusCode(204);
         return BadRequest("Not Found Landmark");
      }
      
   }
}
