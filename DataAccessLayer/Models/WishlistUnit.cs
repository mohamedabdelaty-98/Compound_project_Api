using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
