using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class WishlistUnit
    {
        public int Id { get; set; }
        [ForeignKey("wishlist")]
        public int WihslistId { get; set; }
        public virtual Wishlist? wishlist { get; set; }
        [ForeignKey("unit")]
        public int UnitId { get; set; }
        public virtual Unit? unit { get; set; }
    }
}
