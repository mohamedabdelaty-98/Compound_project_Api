using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO.ReviewDTO
{
   public class ReviewCreateReturn
   {
      public required Review review { get; set; }
      public required string URL { get; set; }
   }
}
