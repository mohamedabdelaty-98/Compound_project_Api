using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IUnitComponent:IGenericReposatory<UnitComponent>
    {
        public List<UnitComponent> GetUnitComponents(int unitid);
    }
}
