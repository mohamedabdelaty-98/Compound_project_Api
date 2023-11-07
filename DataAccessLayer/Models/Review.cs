using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        [MaxLength(1000)]
        public string ReviewText { get; set; }
        [Column(TypeName ="date")]
        public DateTime DatePosted { get; set; }
        [ForeignKey("user")]
        public string UserId020 { get; set; }
        public virtual User? user { get; set; }
    }
}
