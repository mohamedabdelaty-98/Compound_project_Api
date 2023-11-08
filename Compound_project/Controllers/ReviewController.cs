using AutoMapper;
using BussienesLayer.DTO;
using BussienesLayer.DTO.ReviewDTO;
using Compound_project.Reposatories.ReviewReposatory;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using DataAccessLayer.Reposatories.ReviewReposatory;
using DataAccessLayer.Reposatories.UserReposatory;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
   public class ReviewController : ControllerBase
   {
      private readonly IMapper _mapper;
        private readonly IReviewReposatory _reviewReposatory;
        private readonly IUser _user;
      private readonly IReviewOperationsReposatory _ReviewOperationsReposatory;

      public ReviewController(IReviewOperationsReposatory _ReviewOperationsReposatory,
         IMapper _mapper, IReviewReposatory _reviewReposatory,IUser _user)
      {
         this._ReviewOperationsReposatory = _ReviewOperationsReposatory;
         this._mapper = _mapper;
            this._reviewReposatory = _reviewReposatory;
            this._user = _user;
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

        [HttpGet("GetAllReviews")]

        public ActionResult<DTOResult> GetAllReviews()
        {
            List<Review> reviews = _reviewReposatory.GetAll(r=>r.user);
            List<DTOReviews> dtoreviews = reviews.Select(item => _mapper.Map<DTOReviews>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dtoreviews.Count != 0 ? true : false;
            result.Data = dtoreviews;
            return result;
        }


   }
}
