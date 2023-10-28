using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.Reposatories
{
    public interface IUnitComponent:ICrudOperation<UnitComponent>
    {
        public List<UnitComponent> GetUnitComponents(int unitid);
    }
}
