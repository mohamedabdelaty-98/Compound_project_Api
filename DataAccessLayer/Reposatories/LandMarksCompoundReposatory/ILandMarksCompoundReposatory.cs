using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories.LandMarksCompoundReposatory
{
   public interface ILandMarksCompoundReposatory
   {
      List<LandMarksCompound> GetLandMarksCompounds();
      List<LandMarksCompound> GetLandMarksCompounds(int CompoundId);
      LandMarksCompound? GetById(int id);
   }
}
