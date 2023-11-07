using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public class CompoundRepo : GenericReposatory<Compound>, ICompound
    {
        private readonly Context context;

        public CompoundRepo(Context context) : base(context)
        {
            this.context = context;

        }


    }
}
