using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandmarkReposatory;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Reposatories.ReviewReposatory
{
    public class ReviewReposatory : GenericReposatory<Review>, IReviewReposatory
   {
        private readonly Context context;

        public ReviewReposatory(Context context) : base(context)
        {
            this.context = context;
        }
        public Review? GetById(int id)
      {
         using var Context = new Context();
         return Context.reviews.FirstOrDefault(l => l.Id == id);
      }

      public List<Review> GetReviewByUserId(string UserId)
      {
         using var Context = new Context();
         return Context.reviews.Include(l => l.user)
            .Where(c=>c.user.Id== UserId)
            .ToList();
      }
   }
}
