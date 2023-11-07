using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public class ServicesCompound_Repo : GenericReposatory<ServicesCompound>, IServicesCompound
    {
        private readonly Context context;

        public ServicesCompound_Repo(Context context) : base(context)
        {
            this.context = context;

        }

        public List<ServicesCompound> GetServicesCompound(int CompoundID)
        {
            List<ServicesCompound> servicesCompounds = context.servicesCompounds.Where(sc => sc.CompoundId == CompoundID).ToList();
            return servicesCompounds;
        }
    }
}
