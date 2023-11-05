using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories.LandMarksCompoundReposatory
{
    public class LandMarksCompoundReposatory: GenericReposatory<LandMarksCompound>,ILandMarksCompoundReposatory
   {
        private readonly Context context;

        public LandMarksCompoundReposatory(Context context) : base(context)
        {
            this.context = context;
        }

        public List<LandMarksCompound> GetCompoundlandmarks(int CompoundId)
        {
            List<LandMarksCompound> landMarksCompounds = context.landMarksCompounds.Where(obj => obj.CompoundId == CompoundId).ToList();
            return landMarksCompounds;
        }

        public LandMarksCompound GetCompoundlandmarksDescription(int landmarkid)
        {
            return context.landMarksCompounds.FirstOrDefault(l => l.LandMarkId == landmarkid);
        }
    }
}
