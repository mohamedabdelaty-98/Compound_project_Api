using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories.ReviewReposatory
{
    public interface IReviewReposatory : IGenericReposatory<Review>
    {
      List<Review> GetReviewByUserId(string UserId);
      Review? GetById(int id);
   }
}
