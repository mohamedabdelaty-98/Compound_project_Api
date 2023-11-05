using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories.ReviewReposatory
{
    public interface IReviewReposatory
   {
      List<Review> GetReviewByUserId(string UserId);
      Review? GetById(int id);
   }
}
