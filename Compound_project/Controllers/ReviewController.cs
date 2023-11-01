using AutoMapper;
using BussienesLayer.DTO.LandMarksCompoundDTO;
using BussienesLayer.DTO.ReviewDTO;
using Compound_project.Reposatories.ReviewReposatory;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandMarksCompoundReposatory;
using DataAccessLayer.Reposatories.ReviewReposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ReviewController : ControllerBase
   {
      private readonly IMapper _mapper;
      private readonly IReviewOperationsReposatory _ReviewOperationsReposatory;

      public ReviewController(IReviewOperationsReposatory _ReviewOperationsReposatory,
         IMapper _mapper)
      {
         this._ReviewOperationsReposatory = _ReviewOperationsReposatory;
         this._mapper = _mapper;
      }
      
      [HttpPost]
      public async Task<IActionResult> CreateReview(ReviewDTO _LandMarksCompoundDTO)
      {
         ReviewCreateReturn landmarksCompundCreateReturn = await _ReviewOperationsReposatory.Create(_LandMarksCompoundDTO);
         if (landmarksCompundCreateReturn.review != null)
            return Created(landmarksCompundCreateReturn.URL
               , new
               {
                  landmarksCompundCreateReturn.review.Rating,
                  landmarksCompundCreateReturn.review.ReviewText,
                  landmarksCompundCreateReturn.review.DatePosted,
                  landmarksCompundCreateReturn.review.UserId020
               });

         return BadRequest();
      }

      [HttpPut("{id:int}")]
      public async Task<IActionResult> UpdateLandmark(int id, ReviewDTO reviewDTO, IReviewReposatory _ReviewReposatory)
      {
         if (ModelState.IsValid == true)
         {
            bool FindReview = await _ReviewOperationsReposatory.Update(id, reviewDTO, _ReviewReposatory);
            if (FindReview == true)
               return StatusCode(204, reviewDTO);

            return BadRequest("Not Found Landmark");
         }
         return BadRequest("ModelState Not Valid");
      }

      [HttpDelete("{id:int}")]
      public async Task<IActionResult> DelteLandmark(int id, IReviewReposatory _ReviewReposatory)
      {
         bool FindReview = await _ReviewOperationsReposatory.Delete(id, _ReviewReposatory);
         if (FindReview == true)
            return StatusCode(204);
         return BadRequest("Not Found Landmark");
      }
      [HttpGet("{UserId}")]
      public IActionResult GetRevieByUserId(string UserId, IReviewReposatory _ReviewReposatory)
      {

         List<Review> landMarksCompounds = _ReviewReposatory.GetReviewByUserId(UserId);

         var landMarksCompoundsDTO =
            landMarksCompounds.Select(item => _mapper.Map<Review_IncludeUserDTO>(item)).ToList();


         return Ok(landMarksCompoundsDTO);
      }


   }
}
