using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public interface Icomponent:ICrudOperation<CComponent>
    {
        public CComponent GetbyName(string name);
    }
}
