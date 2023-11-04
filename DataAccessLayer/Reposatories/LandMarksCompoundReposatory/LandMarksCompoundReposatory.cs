using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories.LandMarksCompoundReposatory
{
   public class LandMarksCompoundReposatory: ILandMarksCompoundReposatory
   {
      public List<LandMarksCompound> GetLandMarksCompounds()
      {
         using var Context = new Context();
         return Context.landMarksCompounds.Include(l => l.landmark)
            .Include(c=>c.compound)
            .ToList();
      }
      public LandMarksCompound? GetById(int id)
      {
         using var Context = new Context();
         return Context.landMarksCompounds.FirstOrDefault(l => l.Id == id);
      }

      public List<LandMarksCompound> GetLandMarksCompounds(int CompoundId)
      {
         using var Context = new Context();
         return Context.landMarksCompounds.Include(l => l.landmark)
            .Include(c => c.compound)
            .Where(c=>c.CompoundId==CompoundId)
            .ToList();
      }
   }
}
