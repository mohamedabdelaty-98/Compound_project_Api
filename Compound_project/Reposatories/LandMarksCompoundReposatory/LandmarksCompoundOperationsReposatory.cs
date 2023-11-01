using BussienesLayer.DTO.LandmarkDTO;
using BussienesLayer.DTO.LandMarksCompoundDTO;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandmarkReposatory;
using DataAccessLayer.Reposatories.LandMarksCompoundReposatory;
using Microsoft.EntityFrameworkCore;

namespace Compound_project.Reposatories.LandMarksCompoundReposatory
{
   public class LandmarksCompoundOperationsReposatory: ILandmarksCompoundOperationsReposatory
   {
      public async Task AddLandMarkInDatabase(LandMarksCompound landMarksCompound)
      {
         using var context = new Context();
         context.landMarksCompounds.Add(landMarksCompound);
         await context.SaveChangesAsync();
      }
      public async Task<LandmarksCompundCreateReturn> Create(LandMarksCompoundDTO landMarksCompoundDTO)
      {
         LandMarksCompound? landMarksCompound = new LandMarksCompound
         {
            Description = landMarksCompoundDTO.Description,
            LandMarkId=landMarksCompoundDTO.LandMarkId,
            CompoundId= landMarksCompoundDTO.CompoundId
         };

         await AddLandMarkInDatabase(landMarksCompound);
         string URL = "http://localhost:5117/api/Landmark/" + landMarksCompound.Id;

         return new LandmarksCompundCreateReturn
         {
            landMarksCompound = landMarksCompound,
            URL = URL
         };
      }

      public async Task<bool> Update(int id, LandMarksCompoundDTO landmarkOperationsDTO, ILandMarksCompoundReposatory _LandMarksCompoundReposatory)
      {
         using var Context = new Context();
         LandMarksCompound? landMarksCompound = _LandMarksCompoundReposatory.GetById(id);
         if (landMarksCompound != null)
         {
            landMarksCompound.Description = landmarkOperationsDTO.Description;
            landMarksCompound.CompoundId = landmarkOperationsDTO.CompoundId;
            landMarksCompound.LandMarkId = landmarkOperationsDTO.LandMarkId;
            Context.Entry(landMarksCompound).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return true;
         }
         return false;
      }

      public async Task<bool> Delete(int id, ILandMarksCompoundReposatory _LandMarksCompoundReposatory)
      {
         using var Context = new Context();
         LandMarksCompound ? landMarksCompound = _LandMarksCompoundReposatory.GetById(id);
         if (landMarksCompound != null)
         {
            Context.landMarksCompounds.Remove(landMarksCompound);
            await Context.SaveChangesAsync();
            return true;
         }
         return false;
      }
   }
}
