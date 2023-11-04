using BussienesLayer.DTO.LandmarkDTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandmarkReposatory;

namespace Compound_project.Reposatories.LandmarkReposatory
{
   public interface ILandmarkOperationsReposatory
   {
      Task<LandmarkCreateReturn> Create(LandmarkOperationsDTO landmarkOperationsDTO);
      Task<bool> Update(int id, LandmarkOperationsDTO landmarkOperationsDTO, ILandmarkReposatory _LandmarkReposatory);

      Task<bool> Delete(int id, ILandmarkReposatory _LandmarkReposatory);
   }
}
