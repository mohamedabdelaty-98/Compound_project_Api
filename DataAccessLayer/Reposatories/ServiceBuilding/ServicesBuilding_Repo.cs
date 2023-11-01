using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Reposatories
{
    public class ServicesBuilding_Repo : GenericReposatory<ServiceBuilding>, IServicesBuilding
    {
        private readonly Context context;

        public ServicesBuilding_Repo(Context context) : base(context)
        {
            this.context = context;

        }
        public object Entry(ServiceBuilding AmmenitiesBuilding)
        {
            throw new NotImplementedException();
        }

        public Service GetbyName(string name)
        {
            return context.services.FirstOrDefault(c => c.Name == name);
        }
    }
}
