using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public class ServicesCompound_Repo : CrudOperation<ServicesCompound>, IServicesCompound
    {
        private readonly Context context;

        public ServicesCompound_Repo(Context context) : base(context)
        {
            this.context = context;

        }

       
        public object Entry(ServicesCompound Ammenitiescompound)
        {
            throw new NotImplementedException();
        }
        public Service GetbyName(string name)
        {
            return context.services.FirstOrDefault(c => c.Name == name);
        }
    }
}
