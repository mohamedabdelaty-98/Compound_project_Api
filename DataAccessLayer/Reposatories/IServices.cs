using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public interface IServices:ICrudOperation<Service>
    {
        public Service GetbyName(string name);
        object Entry(Service Ammenities);
        
        
    }

}
