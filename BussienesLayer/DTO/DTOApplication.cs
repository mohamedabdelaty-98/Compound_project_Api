using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO
{
 public class DTOApplication
  {
    public int Id { get; set; }
    public string SSN { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
   public double Budget { get; set; }
   public string ContactEmail { get; set; }
        public int FloorNumber { get; set; }

        public string UserId { get; set; }
 

  }
}
