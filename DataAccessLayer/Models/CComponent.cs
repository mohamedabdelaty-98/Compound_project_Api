using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class CComponent
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual List<UnitComponent>? unitComponents { get; set; }=new List<UnitComponent>();
    }
}
