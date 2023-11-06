using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class ServiceBuilding
    {
        public int Id { get; set; }
        [ForeignKey("building")]
        public int BuildingId { get; set; }
        public virtual Building? building { get; set; }
        [ForeignKey("services")]
        public int? ServiceId { get; set; }
        public virtual Service? service { get; set; }
    }
}
