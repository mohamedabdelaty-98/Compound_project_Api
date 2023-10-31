using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
  public class WishListUnitRepo:CrudOperation<WishlistUnit>,IWishListUnit
  {
    private readonly Context context;

    public WishListUnitRepo(Context context) : base(context)
    {
      this.context = context;
    }
  }
}
