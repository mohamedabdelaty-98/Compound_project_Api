using BussienesLayer.DTO.LandMarksCompoundDTO;
using BussienesLayer.DTO.ReviewDTO;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandMarksCompoundReposatory;
using DataAccessLayer.Reposatories.ReviewReposatory;
using Microsoft.EntityFrameworkCore;

namespace Compound_project.Reposatories.ReviewReposatory
{
   public class ReviewOperationsReposatory : IReviewOperationsReposatory
   {
      public async Task AddLandMarkInDatabase(Review review)
      {
         using var context = new Context();
         context.reviews.Add(review);
         await context.SaveChangesAsync();
      }

      public async Task<ReviewCreateReturn> Create(ReviewDTO reviewDTO)
      {
         Review? review = new Review();
         if (reviewDTO != null)
         {
            review.Rating = reviewDTO.Rating;
            if (reviewDTO.ReviewText != null)
               review.ReviewText = reviewDTO.ReviewText;
            if (reviewDTO.UserId != null)
               review.UserId020 = reviewDTO.UserId;
         }

         await AddLandMarkInDatabase(review);
         string URL = "http://localhost:5117/api/Landmark/" + review.Id;

         return new ReviewCreateReturn
         {
            review = review,
            URL = URL
         };
      }

      public async Task<bool> Update(int id, ReviewDTO reviewDTO, IReviewReposatory _ReviewReposatory)
      {
         using var Context = new Context();
         Review? landMarksCompound = _ReviewReposatory.GetById(id);
         if (landMarksCompound != null)
         {
            landMarksCompound.Rating = reviewDTO.Rating;
            if (reviewDTO.ReviewText != null)
               landMarksCompound.ReviewText = reviewDTO.ReviewText;
            landMarksCompound.DatePosted = reviewDTO.DatePosted;
            if (reviewDTO.UserId != null)
               landMarksCompound.UserId020 = reviewDTO.UserId;
            Context.Entry(landMarksCompound).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return true;
         }
         return false;
      }

      public async Task<bool> Delete(int id, IReviewReposatory _ReviewReposatory)
      {
         using var Context = new Context();
         Review? review = _ReviewReposatory.GetById(id);
         if (review != null)
         {
            Context.reviews.Remove(review);
            await Context.SaveChangesAsync();
            return true;
         }
         return false;
      }
   }
}
