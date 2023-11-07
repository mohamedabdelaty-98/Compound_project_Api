using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IServicesUnit:IGenericReposatory<ServiceUnit>
    {
        public List<ServiceUnit> GetServicesUnitByUint(int UnitId);
    }
}
