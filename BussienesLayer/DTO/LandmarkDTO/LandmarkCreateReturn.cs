using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO.LandmarkDTO
{
   public class LandmarkCreateReturn
   {
      public required Landmark Landmark { get; set; }
      public required string URL { get; set; }
   }
}
