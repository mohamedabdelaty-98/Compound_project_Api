using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public class ComponentRepo : GenericReposatory<CComponent>, Icomponent
    {
        private readonly Context context;

        public ComponentRepo(Context context) : base(context)
        {
            this.context = context;
        }

        public CComponent GetbyName(string name)
        {
            return context.components.FirstOrDefault(c=>c.Name.ToLower()==name.ToLower());
        }
    }
}
