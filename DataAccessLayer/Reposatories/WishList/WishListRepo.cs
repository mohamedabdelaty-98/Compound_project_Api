using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public class WishListRepo : GenericReposatory<Wishlist>, IWishList
  {
    private readonly Context context;

    public WishListRepo(Context context) : base(context)
    {
      this.context = context;
    }

   
  }
}
