using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.Reposatories
{
    public class UnitImageRepo : CrudOperation<UnitImage>,IUnitImage
    {
        private readonly Context context;
        public UnitImageRepo(Context context):base(context)
        {
            this.context = context;
        }
        public List<UnitImage> GetUnitImages(int UnitId)
        {
            List<UnitImage> UnitImages = context.unitImages.Where(obj=>obj.UnitId== UnitId).ToList();
            return UnitImages;
        }
    }
}
