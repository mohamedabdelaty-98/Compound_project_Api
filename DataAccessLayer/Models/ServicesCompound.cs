using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class ServicesCompound
    {
        public int Id { get; set; }
        [ForeignKey("compound")]
        public int CompoundId { get; set; }
        public virtual Compound? compound { get; set; }
        [ForeignKey("services")]
        public int? ServiceId { get; set; }
        public virtual Service? services { get; set; }
    }
}
