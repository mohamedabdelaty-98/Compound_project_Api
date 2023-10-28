using DataAccessLayer.Models;

namespace Compound_project.DTO
{
    public class DTOUnit
    {
        public int Id { get; set; }
        public int UnitNumber { get; set; }
        public int Floor { get; set; }
        public string Description { get; set; }
        public int NumberOfBedrooms { get; set; }
        public decimal Price { get; set; }
        public double Area { get; set; }
        public string status { get; set; }
        public int BulidingNumber { get; set; }
        public List<DTOUnitComponent> unitcomponents { get; set; }

    }
}
