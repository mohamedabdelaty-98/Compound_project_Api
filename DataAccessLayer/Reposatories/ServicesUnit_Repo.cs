using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public class ServicesUnit_Repo : CrudOperation<ServiceUnit>, IServicesUnit
    {

        private readonly Context context;

        public ServicesUnit_Repo(Context context) : base(context)
        {
            this.context = context;

        }
        public object Entry(ServiceUnit Ammenitiesunit)
        {
            throw new NotImplementedException();
        }

        public Service GetbyName(string name)
        {
            return context.services.FirstOrDefault(c => c.Name == name);
        }
    }
}
