using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO.ReviewDTO
{
   public class ReviewDTO
   {
      public int Rating { get; set; }
      public string? ReviewText { get; set; }
      public DateTime DatePosted { get; set; }
      public string? UserId { get; set; }
   }
}
