using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IServicesBuilding:IGenericReposatory<ServiceBuilding>
    {
        public List<ServiceBuilding> GetServiceBuilding(int Buildingid);
    }
}
