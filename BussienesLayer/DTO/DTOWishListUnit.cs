using DataAccessLayer.Models;

namespace BussienesLayer.DTO
{
    public class DTOWishListUnit
  {
    public int Id { get; set; }
   
    public int WihslistId { get; set; }
    public virtual Wishlist? wishlist { get; set; }
    public string user_Id { get; set; }
    public string UserName { get; set; }
    public int UnitId { get; set; }
    public virtual Unit? unit { get; set; }
  }
}
