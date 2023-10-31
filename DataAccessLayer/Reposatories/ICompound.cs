using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public interface ICompound : ICrudOperation<Compound>
    {
        object Entry(Compound oldcompound);
    }
}
