using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class UnitImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("unit")]
        public int UnitId { get; set; }
        public virtual Unit? unit { get; set; }
    }
}
