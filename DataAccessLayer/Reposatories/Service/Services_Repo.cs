using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public class Services_Repo : GenericReposatory<Service>, IServices
    {
        private readonly Context context;

        public Services_Repo(Context context) : base(context)
        {
            this.context = context;

        }

        public Service GetbyName(string name)
        {
            return context.services.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
