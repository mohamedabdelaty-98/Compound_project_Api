using BussienesLayer.DTO.LandmarkDTO;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandmarkReposatory;
using Microsoft.EntityFrameworkCore;

namespace Compound_project.Reposatories.LandmarkReposatory
{
   public class LandmarkOperationsReposatory: ILandmarkOperationsReposatory
   {
      
      public async Task AddLandMarkInDatabase(Landmark landmark)
      {
         using var context = new Context();
         context.landmarks.Add(landmark);
         await context.SaveChangesAsync();
      }
      public async Task<LandmarkCreateReturn> Create(LandmarkOperationsDTO landmarkOperationsDTO)
      {
         Landmark? landmark = new Landmark
         {
            Name = landmarkOperationsDTO.Name
         };
         await AddLandMarkInDatabase(landmark);
         string URL = "http://localhost:5117/api/Landmark/" + landmark.Id;

         return new LandmarkCreateReturn
         {
            Landmark = landmark,
            URL = URL
         };
      }

      public async Task<bool> Update(int id, LandmarkOperationsDTO landmarkOperationsDTO, ILandmarkReposatory _LandmarkReposatory)
      {
         using var Context = new Context();
         Landmark? landmark= landmark = _LandmarkReposatory.GetById(id);
         if (landmark != null)
         {
            landmark.Name = landmarkOperationsDTO.Name;
            Context.Entry(landmark).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return true;
         }
         return false;
      }

      public async Task<bool> Delete(int id, ILandmarkReposatory _LandmarkReposatory)
      {
         using var Context = new Context();
         Landmark? landmark = landmark = _LandmarkReposatory.GetById(id);
         if (landmark != null)
         {
            Context.landmarks.Remove(landmark);
            await Context.SaveChangesAsync();
            return true;
         }
         return false;
      }
   }
}
