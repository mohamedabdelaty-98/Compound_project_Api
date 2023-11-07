using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IUnitImage:IGenericReposatory<UnitImage>
    {
        public List<UnitImage> GetUnitImages(int UnitId);
    }
}
