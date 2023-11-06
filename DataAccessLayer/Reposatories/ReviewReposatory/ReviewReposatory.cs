﻿using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Reposatories.ReviewReposatory
{
    public class ReviewReposatory: IReviewReposatory
   {
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
