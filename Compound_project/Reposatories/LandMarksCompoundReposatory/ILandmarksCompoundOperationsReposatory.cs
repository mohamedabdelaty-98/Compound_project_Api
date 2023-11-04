using BussienesLayer.DTO.LandMarksCompoundDTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandMarksCompoundReposatory;

namespace Compound_project.Reposatories.LandMarksCompoundReposatory
{
   public interface ILandmarksCompoundOperationsReposatory
   {
      Task<LandmarksCompundCreateReturn> Create(LandMarksCompoundDTO landMarksCompoundDTO);
      Task<bool> Update(int id, LandMarksCompoundDTO landmarkOperationsDTO, ILandMarksCompoundReposatory _LandMarksCompoundReposatory);
      Task<bool> Delete(int id, ILandMarksCompoundReposatory _LandMarksCompoundReposatory);
   }
}
