using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.Reposatories
{
    public interface IUnitImage:ICrudOperation<UnitImage>
    {
        public List<UnitImage> GetUnitImages(int UnitId);
    }
}
