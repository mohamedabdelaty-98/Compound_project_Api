using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
   
   public class Landmark
    {
        public int Id { get; set; }
        public string? Name { get; set; }
      public virtual List<LandMarksCompound>? LandMarksCompounds { get; set; }
        = new List<LandMarksCompound>();

    }
}
