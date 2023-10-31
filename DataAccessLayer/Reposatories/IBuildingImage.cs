using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.Reposatories
{
    public interface IBuildingImage: ICrudOperation<BuildingImage>
    {
        public List<BuildingImage> GetBuildingImages(int BuildingId);
    }
}
