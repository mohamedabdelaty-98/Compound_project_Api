using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class LandMarksCompound
    {
        public int Id { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        [MaxLength(1000)]
        public string? IConName { get; set; }

        [ForeignKey("landmark")]
        public int LandMarkId { get; set; }
        public virtual Landmark? landmark { get; set; }
        [ForeignKey("compound")]
        public int CompoundId { get; set; }
        public virtual Compound? compound { get; set; }
    }
}
