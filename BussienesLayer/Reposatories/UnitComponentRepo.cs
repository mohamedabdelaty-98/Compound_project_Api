using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.Reposatories
{
    public class UnitComponentRepo : CrudOperation<UnitComponent>, IUnitComponent
    {
        private readonly Context context;

        public UnitComponentRepo(Context context) : base(context)
        {
            this.context = context;
        }

        public List<UnitComponent> GetUnitComponents(int unitid)
        {
            List<UnitComponent> unitComponents=
                context.unitComponents.Where(u=>u.UnitId == unitid)
                .Include(c=>c.component).ToList();
            return unitComponents;
        }
    }
}
