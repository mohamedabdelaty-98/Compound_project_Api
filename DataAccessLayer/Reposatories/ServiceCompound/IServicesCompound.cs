using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IServicesCompound:IGenericReposatory<ServicesCompound>
    {
        List<ServicesCompound> GetServicesCompound(int CompoundID);
    }
}
