using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IBuildingImage: IGenericReposatory<BuildingImage>
    {
        public List<BuildingImage> GetBuildingImages(int BuildingId);
    }
}
