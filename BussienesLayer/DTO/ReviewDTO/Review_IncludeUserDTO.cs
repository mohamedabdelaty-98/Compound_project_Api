using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO.ReviewDTO
{
   public class Review_IncludeUserDTO
   {
      public int Id { get; set; }
      public int Rating { get; set; }
      public string? ReviewText { get; set; }
      public DateTime DatePosted { get; set; }
      public string? FullName { get;}
   }
}
