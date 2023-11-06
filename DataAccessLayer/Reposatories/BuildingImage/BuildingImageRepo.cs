using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public class BuildingImageRepo : GenericReposatory<BuildingImage>, IBuildingImage
    {
        private readonly Context context;
        public BuildingImageRepo(Context context):base(context) { 
        this.context = context;

        }
        public List<BuildingImage> GetBuildingImages(int BuildingId)
        {
            List<BuildingImage> BuildingImages = context.BuildingImages.Where(obj => obj.BuildingId == BuildingId).ToList();
            return BuildingImages;
        }


    }
}
