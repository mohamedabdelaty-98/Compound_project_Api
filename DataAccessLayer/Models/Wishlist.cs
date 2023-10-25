using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
