namespace BussienesLayer.DTO
{
    public class DTOServicesBuilding
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? BuildingId { get; set; }
        public int? ServiceId { get; set; }
    }
}
