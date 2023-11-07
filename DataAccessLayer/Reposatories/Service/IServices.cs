using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IServices:IGenericReposatory<Service>
    {
        public Service GetbyName(string name);
    }

}
