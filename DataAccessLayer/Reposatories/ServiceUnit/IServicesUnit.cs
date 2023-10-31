using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public interface IServicesUnit:IGenericReposatory<ServiceUnit>
    {
        object Entry(ServiceUnit Ammenitiesunit);


    }
}
