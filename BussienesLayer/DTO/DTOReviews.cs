using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.DTO
{
    public class DTOReviews
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime DatePosted { get; set; }
        public string FName { get; set;}
        public string LName { get; set;}

    }

}
