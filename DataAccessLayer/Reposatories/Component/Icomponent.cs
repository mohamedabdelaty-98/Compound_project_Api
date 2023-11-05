using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface Icomponent:IGenericReposatory<CComponent>
    {
        public CComponent GetbyName(string name);
    }
}
