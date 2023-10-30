using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Compound
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Column(TypeName ="date")]
        public DateTime DateAdded { get; set; }
        [MaxLength(100)]
        public string File { get; set; }

        public double Street_area { get; set; }
        public double GreenArea { get; set; }
        public double BuildingArea { get; set; }
        public virtual List<Building>? buildings { get; set; } = new List<Building>();
        public virtual List<LandMarksCompound>? landMarksCompounds { get; set; } = new List<LandMarksCompound>();
        public virtual List<CompoundImage>? imageCompounds { get; set; } = new List<CompoundImage>();
        public virtual List<ServicesCompound>? servicesCompounds { get; set; } = new List<ServicesCompound>();
    }
}
