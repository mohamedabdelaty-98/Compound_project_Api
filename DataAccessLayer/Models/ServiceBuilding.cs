using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ServiceBuilding
    {
        public int Id { get; set; }
        [ForeignKey("building")]
        public int BuildingId { get; set; }
        public virtual Building? building { get; set; }
        [ForeignKey("services")]
        public int ServiceId { get; set; }
        public virtual Service? service { get; set; }
    }
}
