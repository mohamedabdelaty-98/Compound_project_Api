using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO.LandMarksCompoundDTO
{
   public class LandmarksCompundCreateReturn
   {
      public required LandMarksCompound landMarksCompound { get; set; }
      public required string URL { get; set; }
   }
}
