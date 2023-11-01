using AutoMapper;
using BussienesLayer.DTO.LandmarkDTO;
using BussienesLayer.DTO.LandMarksCompoundDTO;
using BussienesLayer.Reposatories;
using Compound_project.DTO;
using Compound_project.Reposatories.LandMarksCompoundReposatory;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandmarkReposatory;
using DataAccessLayer.Reposatories.LandMarksCompoundReposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class LandMarksCompoundController : ControllerBase
   {
      private readonly IMapper _mapper;
      private readonly ILandmarksCompoundOperationsReposatory _LandmarksCompoundOperationsReposatory;
      public LandMarksCompoundController(ILandmarksCompoundOperationsReposatory _LandmarksCompoundOperationsReposatory,
         IMapper _mapper)
      {
         this._LandmarksCompoundOperationsReposatory = _LandmarksCompoundOperationsReposatory;
         this._mapper= _mapper;
      }
      
      [HttpPost]
      public async Task<IActionResult> CreateLandmark(LandMarksCompoundDTO _LandMarksCompoundDTO)
      {
         LandmarksCompundCreateReturn landmarksCompundCreateReturn = await _LandmarksCompoundOperationsReposatory.Create(_LandMarksCompoundDTO);
         if (landmarksCompundCreateReturn.landMarksCompound != null)
            return Created(landmarksCompundCreateReturn.URL
               , new { landmarksCompundCreateReturn.landMarksCompound.Description,
                  landmarksCompundCreateReturn.landMarksCompound.LandMarkId,
                  landmarksCompundCreateReturn.landMarksCompound.CompoundId
               });

         return BadRequest();
      }

      [HttpPut("{id:int}")]
      public async Task<IActionResult> UpdateLandmark(int id, LandMarksCompoundDTO landMarksCompoundDTO, ILandMarksCompoundReposatory _LandMarksCompoundReposatory)
      {
         if (ModelState.IsValid == true)
         {
            bool FindLandmark = await _LandmarksCompoundOperationsReposatory.Update(id, landMarksCompoundDTO, _LandMarksCompoundReposatory);
            if (FindLandmark == true)
               return StatusCode(204, landMarksCompoundDTO);

            return BadRequest("Not Found Landmark");
         }
         return BadRequest("ModelState Not Valid");
      }

      [HttpDelete("{id:int}")]
      public async Task<IActionResult> DelteLandmark(int id, ILandMarksCompoundReposatory _LandMarksCompoundReposatory)
      {
         bool FindLandmark = await _LandmarksCompoundOperationsReposatory.Delete(id, _LandMarksCompoundReposatory);
         if (FindLandmark == true)
            return StatusCode(204);
         return BadRequest("Not Found Landmark");
      }
      [HttpGet]
      public IActionResult GetLandMarksCompounds(ILandMarksCompoundReposatory _LandMarksCompoundReposatory)
      {

         List<LandMarksCompound> landMarksCompounds = _LandMarksCompoundReposatory.GetLandMarksCompounds();
         
         List<LandMarksCompound_IncludeLandmarks_IncludeCompoundDTO> landMarksCompoundsDTO =
            landMarksCompounds.Select(item => _mapper.Map<LandMarksCompound_IncludeLandmarks_IncludeCompoundDTO>(item)).ToList();
         
         
         return Ok(landMarksCompoundsDTO);
      }
      [HttpGet("{IdCompound}")]
      public IActionResult GetLandMarksCompoundsByIdCompound(int IdCompound, ILandMarksCompoundReposatory _LandMarksCompoundReposatory)
      {

         List<LandMarksCompound> landMarksCompounds = _LandMarksCompoundReposatory.GetLandMarksCompounds(IdCompound);

         List<LandMarksCompound_IncludeLandmarks_IncludeCompoundDTO> landMarksCompoundsDTO =
            landMarksCompounds.Select(item => _mapper.Map<LandMarksCompound_IncludeLandmarks_IncludeCompoundDTO>(item)).ToList();


         return Ok(landMarksCompoundsDTO);
      }







   }
}
