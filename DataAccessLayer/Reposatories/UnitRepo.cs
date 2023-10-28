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
    public class UnitRepo : CrudOperation<Unit>, IUnit
    {
        private readonly Context context;

        public UnitRepo(Context context) : base(context)
        {
            this.context = context;
        }

        public List<Unit> FilterByStatus()
        {
            return context.units.Where(u=>u.status==Status.active).ToList();
        }
    }
}
