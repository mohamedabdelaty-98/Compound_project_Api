using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class BuildingImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("building")]
        public int BuildingId { get; set; }
        public virtual Building? building { get; set; }
    }
}
