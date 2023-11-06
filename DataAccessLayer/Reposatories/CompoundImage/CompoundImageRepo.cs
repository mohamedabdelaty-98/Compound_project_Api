using DataAccessLayer.Models;
using DataAccessLayer.Data;

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
