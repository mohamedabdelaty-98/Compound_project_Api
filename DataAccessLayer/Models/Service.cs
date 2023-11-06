using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Service
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [MaxLength(1000)]
        public string? IConName { get; set; }

        public virtual List<ServicesCompound>? servicesCompounds { get; set; }=new List<ServicesCompound>();
        public virtual List<ServiceBuilding>? serviceBuildings { get; set; }=new List<ServiceBuilding>();
        public virtual List<ServiceUnit>? serviceUnits { get; set; }=new List<ServiceUnit>();
    }
}
