using DataAccessLayer.Models;

namespace BussienesLayer.DTO
{
    public class DTOWishList
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }  
    public  List<WishlistUnit>? wishlistUnits { get; set; } = new List<WishlistUnit>();
  }
}
