using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO
{
    public class DTOLandMarksCompound
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? IConName { get; set; }

        public int? CompoundId { get; set; }
        public int? LandMarkId { get; set; }

    }
}
