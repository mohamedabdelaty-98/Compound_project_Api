using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public string UserId { get; set; }
        public virtual User? user { get; set; }
        public virtual List<WishlistUnit>? wishlistUnits { get; set; } = new List<WishlistUnit>();
    }
}
