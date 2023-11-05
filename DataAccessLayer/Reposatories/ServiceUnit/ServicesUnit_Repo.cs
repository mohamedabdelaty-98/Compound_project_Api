using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public class ServicesUnit_Repo : GenericReposatory<ServiceUnit>, IServicesUnit
    {

        private readonly Context context;

        public ServicesUnit_Repo(Context context) : base(context)
        {
            this.context = context;

        }

        public List<ServiceUnit> GetServicesUnitByUint(int UnitId)
        {
            return context.serviceUnits.Where(su => su.UnitId == UnitId).ToList();
        }
    }
}
