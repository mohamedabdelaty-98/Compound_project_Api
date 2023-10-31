using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
  public class WishListRepo : CrudOperation<Wishlist>, IWishList
  {
    private readonly Context context;

    public WishListRepo(Context context) : base(context)
    {
      this.context = context;
    }

   
  }
}
