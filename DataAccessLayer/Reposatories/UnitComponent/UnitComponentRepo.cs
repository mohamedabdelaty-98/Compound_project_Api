using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Reposatories
{
    public class UnitComponentRepo : GenericReposatory<UnitComponent>, IUnitComponent
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
