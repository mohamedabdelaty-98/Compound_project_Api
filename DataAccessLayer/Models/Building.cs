using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public enum Status
    {
        active,sold
    }
    public class Building
    {
        public int Id { get; set; }
        public int BulidingNumber { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public int NumberOfFloor { get; set; }
        [Column(TypeName ="nvarchar(7)")]
        public Status status { get; set; }
        [Column(TypeName ="date")]
        public DateTime DateAdded { get; set; }
        public double SizeArea { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual List<Unit>? Units { get; set; } = new List<Unit>();
        public virtual List<BuildingImage>? imageBuildings { get; set; } = new List<BuildingImage>();
        public virtual List<ServiceBuilding>? serviceBuildings { get; set; } = new List<ServiceBuilding>();
        [ForeignKey("compound")]
        public int CompoundId { get; set; }
        public virtual Compound? compound { get; set; }
    }
}
