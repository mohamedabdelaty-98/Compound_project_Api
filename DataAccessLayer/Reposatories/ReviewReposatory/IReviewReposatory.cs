using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories.ReviewReposatory
{
   public interface IReviewReposatory
   {
      List<Review> GetReviewByUserId(string UserId);
      Review? GetById(int id);
   }
}
