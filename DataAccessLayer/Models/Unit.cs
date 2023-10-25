using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public int UnitNumber { get; set; }
        public int Floor { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public int NumberOfBedrooms { get; set; }
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        public double Area { get; set; }
        [Column(TypeName ="nvarchar(7)")]
        public Status status { get; set; }
        public virtual List<UnitComponent>? unitComponents { get; set; } = new List<UnitComponent>();
        public virtual List<UnitImage>? unitImages { get; set; } = new List<UnitImage>();
        public virtual List<ServiceUnit>? serviceUnits { get; set; } = new List<ServiceUnit>();
        public virtual List<WishlistUnit>? wishlistUnits { get; set; } = new List<WishlistUnit>();
        [ForeignKey("building")]
        public int BuildingId { get; set; }
        public virtual Building? building { get; set; }
    }
}
