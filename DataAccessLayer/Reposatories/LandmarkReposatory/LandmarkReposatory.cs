using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories.LandmarkReposatory
{
   public class LandmarkReposatory: ILandmarkReposatory
   {
      public List<Landmark> GetLandmarks()
      {
         using var Context = new Context();
         return Context.landmarks.Include(l => l.LandMarksCompounds).ToList();
      }

      public Landmark? GetById(int id)
      {
         using var Context = new Context();
         return Context.landmarks.FirstOrDefault(l => l.Id == id);
      }
   }
}
