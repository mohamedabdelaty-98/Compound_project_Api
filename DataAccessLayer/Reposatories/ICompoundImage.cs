using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.Reposatories
{
    public interface ICompoundImage:ICrudOperation<CompoundImage>
    {
        public List<CompoundImage> GetCompoundImages(int CompoundId);
    }
}
