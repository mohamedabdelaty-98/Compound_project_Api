using BussienesLayer.DTO.LandmarkDTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories.LandmarkReposatory;

namespace Compound_project.Reposatories.Landmarks
{
   public class GetAllDTOReposatories: IGetAllDTOReposatories
   {
      ILandmarkReposatory _LandmarkOperations;

      public GetAllDTOReposatories(ILandmarkReposatory _LandmarkOperations)
      {
         this._LandmarkOperations = _LandmarkOperations;
      }

      public List<LandmarkDTO> GetAllDTO()
      {
         List<LandmarkDTO> landmarksDTO = new();
         List<Landmark> landmarks=_LandmarkOperations.GetLandmarks();

         foreach(var item in landmarks)
         {
            landmarksDTO.Add(new LandmarkDTO()
            {
               Id = item.Id,
               Name = item.Name,
               LandMarksCompoundDescription= item?.LandMarksCompounds?.Select(d=>d.Description).ToList()
            });
         }
         return landmarksDTO;
      }



   }
}
