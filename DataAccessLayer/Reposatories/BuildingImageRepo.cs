using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.Reposatories
{
    public class BuildingImageRepo : CrudOperation<BuildingImage>, IBuildingImage
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
