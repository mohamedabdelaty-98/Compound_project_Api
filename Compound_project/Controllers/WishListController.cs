using BussienesLayer.DTO;
using Compound_project.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WishListController : ControllerBase
  {
    private readonly IWishList wishList;

    public WishListController(IWishList wishList)
    {
      this.wishList = wishList;
    }

    [HttpGet("GetAllWishList")]
    public ActionResult<DTOResult> GetAllWishList()

    {
      List<Wishlist> wishlists = wishList.GetAll();
      List<DTOWishList> DTOWishLists = new List<DTOWishList>();
      foreach (var wishlist in wishlists)
      {
        DTOWishList Dtolist = new DTOWishList();
        Dtolist.Id = wishlist.Id;
        Dtolist.UserId = wishlist.user.Id;
        Dtolist.UserName = wishlist.user.UserName;
        foreach (var item in wishlist.wishlistUnits)
        {
          Dtolist.wishlistUnits.Add(item);

        }


      }
      DTOResult result = new DTOResult();
      if (DTOWishLists == null || DTOWishLists.Count == 0) result.IsPass = false;
      else result.IsPass = true;
      result.Data = DTOWishLists;
      return result;



    }
    [HttpGet("{id}")]
    public ActionResult<DTOResult> GetWishById(int id)
    {
      Wishlist wish = wishList.GetById(id);
      DTOWishList dTO = new DTOWishList()
      {
        Id = wish.Id,
        UserName = wish.user.UserName,
        UserId = wish.UserId,


      };
      foreach (WishlistUnit item in wish.wishlistUnits)
      {
        dTO.wishlistUnits.Add(item);
      }

      return Ok(dTO);




    }
    [HttpPost]
    public ActionResult<DTOResult> AddWishlist(Wishlist wish)
    {
      DTOResult result= new DTOResult();
      if (!ModelState.IsValid)
      { result.IsPass = false;
        result.Data = ModelState.Values.SelectMany(v => v.Errors)
      .Select(e => e.ErrorMessage).ToList();
      }
      else
      {
        wishList.insert(wish);
        wishList.save();
        result.IsPass=true;
        result.Data = $"created wish with id{wish.Id}";
      }
      return result;

    }


    [HttpPut("{id}")]
    public ActionResult<DTOResult> EditWishlist(Wishlist list, int id)
    {

      if (list.Id != id) return BadRequest();
      wishList.update(list);
      wishList.save();

      return NoContent();
    }
    [HttpDelete("{id}")]
    public ActionResult<DTOResult> DeleteWishlist(int id)
    {
      Wishlist w = wishList.GetById(id);
      if (w == null) return NotFound();
      wishList.Delete(id);
      wishList.save();
      return Ok(w);
    }

  }
}
