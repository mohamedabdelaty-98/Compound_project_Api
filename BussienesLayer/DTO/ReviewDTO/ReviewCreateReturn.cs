using DataAccessLayer.Models;

namespace BussienesLayer.DTO.ReviewDTO
{
    public class ReviewCreateReturn
   {
      public required Review review { get; set; }
      public required string URL { get; set; }
   }
}
