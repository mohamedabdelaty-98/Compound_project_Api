using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
