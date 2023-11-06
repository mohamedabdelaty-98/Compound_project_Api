using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface ICompoundImage:IGenericReposatory<CompoundImage>
    {
        public List<CompoundImage> GetCompoundImages(int CompoundId);
    }
}
