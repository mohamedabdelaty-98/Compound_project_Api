using AutoMapper;
using BussienesLayer.DTO;
using BussienesLayer.DTO.ReviewDTO;
using Compound_project.Migrations;
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
      public ReviewController(IReviewOperationsReposatory _ReviewOperationsReposatory,
         IMapper _mapper, IReviewReposatory _reviewReposatory,IUser _user)
      {
     
         this._mapper = _mapper;
            this._reviewReposatory = _reviewReposatory;
      }

        [HttpPost("InsertReview")]
        public ActionResult<DTOResult> InsertReview(DTOReviews dTOReviews)
        {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                try
                {
                    Review review = _mapper.Map<Review>(dTOReviews);
                    _reviewReposatory.insert(review);
                    _reviewReposatory.save();
                    result.IsPass = true;
                    result.Data = $"Created unit with ID {review.Id}";
                }
                catch (Exception ex)
                {
                    result.IsPass = false;
                    result.Data = dTOReviews;
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
        [HttpGet("GetReviewsbyUserId/{UserId}")]
      public IActionResult GetReviewsbyUserId(string UserId, IReviewReposatory _ReviewReposatory)
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
