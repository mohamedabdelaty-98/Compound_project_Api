using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public class CompoundRepo : CrudOperation<Compound>, ICompound
    {
        private readonly Context context;

        public CompoundRepo(Context context) : base(context)
        {
            this.context = context;

        }

        public object Entry(Compound oldcompound)
        {
            throw new NotImplementedException();
        }
    }
}
