using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories.LandmarkReposatory
{
   public interface ILandmarkReposatory
   {
      List<Landmark> GetLandmarks();

      Landmark? GetById(int id);
   }
}
