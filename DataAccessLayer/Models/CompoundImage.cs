using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class CompoundImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("compound")]
        public int CompoundId { get; set; }
        public virtual Compound? compound { get; set; }
    }
}
