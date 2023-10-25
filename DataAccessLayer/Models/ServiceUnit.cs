using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ServiceUnit
    {
        public int Id { get; set; }
        [ForeignKey("unit")]
        public int UnitId { get; set; }
        public virtual Unit? unit { get; set; }
        [ForeignKey("service")]

        public int ServiceId { get; set; }
        public virtual Service? service { get; set; }
    }
}
