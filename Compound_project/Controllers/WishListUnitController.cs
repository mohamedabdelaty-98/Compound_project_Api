using BussienesLayer.DTO;
using Compound_project.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WishListUnitController : ControllerBase
  {
    private readonly IWishListUnit wishListUnit;

    public WishListUnitController(IWishListUnit wishListUnit)
    {
      this.wishListUnit = wishListUnit;
    }

    [HttpGet("api/filterByunitid/{id}")]
    public ActionResult<DTOResult> FilterByUnitId(int id)
    {
     List<WishlistUnit>wishunits= wishListUnit.FilterByUnitId(id);
      List<DTOWishListUnit> dTOWishListUnits = new List<DTOWishListUnit>();
      foreach (var item in wishunits)
      {
        DTOWishListUnit dTO = new DTOWishListUnit();
        dTO.Id = item.Id;
        dTO.user_Id = item.wishlist.UserId;
        dTO.UnitId = item.UnitId;
        dTO.WihslistId = item.WihslistId;
        dTO.unit = item.unit;
        dTO.UserName = item.wishlist.user.UserName;
        dTO.wishlist = item.wishlist;


      }
      DTOResult result = new DTOResult();
      if (dTOWishListUnits == null || dTOWishListUnits.Count == 0) result.IsPass = false;
      else result.IsPass = true;
      result.Data = dTOWishListUnits;
      return result;


    }


    [HttpGet("GetAllWishlistUnit")]
    public ActionResult<DTOResult> GetAllWishlistUnit()
    {
      List<WishlistUnit> wishlistUnits = wishListUnit.GetAll();
      List<DTOWishListUnit> dTOWishListUnits = new List<DTOWishListUnit>();
      foreach (var item in wishlistUnits)
      {
        DTOWishListUnit dTO = new DTOWishListUnit();
        dTO.Id = item.Id;
        dTO.user_Id = item.wishlist.UserId;
        dTO.UnitId = item.UnitId;
        dTO.WihslistId = item.WihslistId;
        dTO.unit = item.unit;
        dTO.UserName = item.wishlist.user.UserName;
        dTO.wishlist = item.wishlist;


      }
      DTOResult result = new DTOResult();
      if (dTOWishListUnits == null || dTOWishListUnits.Count == 0) result.IsPass = false;
      else result.IsPass = true;
      result.Data = dTOWishListUnits;
      return result;

    }
    [HttpGet("{id}")]
    public ActionResult<DTOResult> GetWishUnitById(int id)
    {
      WishlistUnit wishunit = wishListUnit.GetById(id);
      DTOWishListUnit dTOUnit = new DTOWishListUnit()
      {
        Id = wishunit.Id,
        WihslistId = wishunit.WihslistId,
        UnitId = wishunit.UnitId,
        user_Id = wishunit.wishlist.user.Id,
        UserName = wishunit.wishlist.user.UserName,
        unit = wishunit.unit,
        wishlist = wishunit.wishlist,

      };
      return Ok(dTOUnit);





    }
    [HttpPost]
    public ActionResult<DTOResult> AddWishlistUnit(WishlistUnit wish)
    {
      DTOResult result = new DTOResult();
      if (!ModelState.IsValid)
       
        {
          result.IsPass = false;
          result.Data = ModelState.Values.SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage).ToList();
        }
        else
      {
        wishListUnit.insert(wish);
        wishListUnit.save();
        result.IsPass = true;
        result.Data = $"created wish with id{wish.Id}";
      }

      return result;
    }


    [HttpPut("{id}")]
    public ActionResult<DTOResult> EditWishlistUnit(WishlistUnit list, int id)
    {

      if (list.Id != id) return BadRequest();
      wishListUnit.update(list);
      wishListUnit.save();

      return NoContent();
    }
    [HttpDelete("{id}")]
    public ActionResult<DTOResult> DeleteWishlistUnit(int id)
    {
      WishlistUnit w = wishListUnit.GetById(id);
      if (w == null) return NotFound();
      wishListUnit.Delete(id);
      wishListUnit.save();
      return Ok(w);
    }

  }
}


