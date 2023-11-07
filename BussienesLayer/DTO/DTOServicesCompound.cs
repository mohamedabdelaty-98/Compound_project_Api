namespace BussienesLayer.DTO
{
    public class DTOServicesCompound
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? IConName { get; set; }

        public int? CompoundId { get; set; }
        public int? ServiceId { get; set; }


    }
}
