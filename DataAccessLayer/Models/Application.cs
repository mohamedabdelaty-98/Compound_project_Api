using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Application
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string SSN { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public double Budget { get; set; }
        public int FloorNumber { get; set; }
        public string UserId { get; set; }
        [MaxLength(100)]
        public string ContactEmail { get; set; }
    }
}
