using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO
{
    public class DTOBuildingImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int BuildingId { get; set; }
    }
}
