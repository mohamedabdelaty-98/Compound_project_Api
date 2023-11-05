using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories.LandMarksCompoundReposatory
{
    public interface ILandMarksCompoundReposatory:IGenericReposatory<LandMarksCompound>
   {
        public List<LandMarksCompound> GetCompoundlandmarks(int CompoundId);
        public LandMarksCompound GetCompoundlandmarksDescription(int landmarkid);
   }
}
