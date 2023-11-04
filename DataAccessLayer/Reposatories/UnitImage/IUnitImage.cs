using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public interface IUnitImage:IGenericReposatory<UnitImage>
    {
        public List<UnitImage> GetUnitImages(int UnitId);
    }
}
