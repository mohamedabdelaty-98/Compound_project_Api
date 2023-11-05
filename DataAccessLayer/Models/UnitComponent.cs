using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class UnitComponent
    {
        public int Id { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        public int NumberComponent { get; set; }
        [ForeignKey("component")]
        public int ComponentId { get; set; }
        public virtual CComponent? component { get; set; }
        [ForeignKey("unit")]
        public int UnitId { get; set; }
        public virtual Unit? unit { get; set; }
    }
}
