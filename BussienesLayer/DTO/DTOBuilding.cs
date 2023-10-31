namespace BussienesLayer.DTO
{
    public class DTOBuilding
    {
        public int Id { get; set; }
        public int BulidingNumber { get; set; }
        public string Description { get; set; }
        public int NumberOfFloor { get; set; }
        public string status { get; set; }
        public DateTime DateAdded { get; set; }
        public double SizeArea { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? CompoundId { get; set; }
        public List<DTOUnit>? Units { get; set; } = new List<DTOUnit>();
    }
}
