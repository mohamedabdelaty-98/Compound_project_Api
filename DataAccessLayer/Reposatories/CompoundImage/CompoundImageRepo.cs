using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public class CompoundImageRepo : GenericReposatory<CompoundImage>, ICompoundImage
    {
        private readonly Context context;
        public CompoundImageRepo(Context context) : base(context)
        {

            this.context = context;
        }
        public List<CompoundImage> GetCompoundImages(int CompoundId)
        {
            List<CompoundImage> CompoundImages = context.CompundImages.Where(obj=>obj.CompoundId == CompoundId).ToList();
            return CompoundImages;
        }


    }
}
