using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public interface IServicesCompound:IGenericReposatory<ServicesCompound>
    {
        public Service GetbyName(string name);

        object Entry(ServicesCompound Ammenitiescompound);


    }
}
