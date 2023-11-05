using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories.LandmarkReposatory
{
    public interface ILandmarkReposatory:IGenericReposatory<Landmark>
   {
      public Landmark GetLandmarkByName(string name);
   }
}
