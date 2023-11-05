using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
