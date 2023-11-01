using BussienesLayer.DTO.Compound;
using BussienesLayer.DTO.LandmarkDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO.LandMarksCompoundDTO
{
   public class LandMarksCompound_IncludeLandmarks_IncludeCompoundDTO
   {
      public int Id { get; set; }
      public string? Description { get; set; }
      public int LandMarkId { get; set; }
      public required LandmarkOperationsDTO landmark { get; set; }
      public CompoundOperationsDTO? compound { get; set; }
   }
}
