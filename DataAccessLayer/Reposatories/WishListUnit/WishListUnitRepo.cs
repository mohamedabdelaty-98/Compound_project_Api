using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public class WishListUnitRepo:GenericReposatory<WishlistUnit>,IWishListUnit
  {
    private readonly Context context;

    public WishListUnitRepo(Context context) : base(context)
    {
      this.context = context;
    }
  }
}
