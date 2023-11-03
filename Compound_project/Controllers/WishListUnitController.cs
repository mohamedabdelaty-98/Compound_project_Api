//using BussienesLayer.DTO;
//using DataAccessLayer.Models;
//using DataAccessLayer.Reposatories;
//using Microsoft.AspNetCore.Mvc;

//namespace Compound_project.Controllers
//{
//    [Route("api/[controller]")]
//  [ApiController]
//  public class WishListUnitController : ControllerBase
//  {
//    private readonly IWishListUnit wishListUnit;

//    public WishListUnitController(IWishListUnit wishListUnit)
//    {
//      this.wishListUnit = wishListUnit;
//    }
//    [HttpGet("GetAllWishlistUnit")]
//    public ActionResult<DTOResult> GetAllWishlistUnit()
//    {
//      List<WishlistUnit> wishlistUnits = wishListUnit.GetAll();
//      List<DTOWishListUnit> dTOWishListUnits = new List<DTOWishListUnit>();
//      foreach (var item in wishlistUnits)
//      {
//        DTOWishListUnit dTO = new DTOWishListUnit();
//        dTO.Id = item.Id;
//        dTO.user_Id = item.wishlist.UserId;
//        dTO.UnitId = item.UnitId;
//        dTO.WihslistId = item.WihslistId;
//        dTO.unit = item.unit;
//        dTO.UserName = item.wishlist.user.UserName;
//        dTO.wishlist = item.wishlist;


//      }
//      DTOResult result = new DTOResult();
//      if (dTOWishListUnits == null || dTOWishListUnits.Count == 0) result.IsPass = false;
//      else result.IsPass = true;
//      result.Data = dTOWishListUnits;
//      return result;

//    }
//    [HttpGet("{id}")]
//    public ActionResult<DTOResult> GetWishUnitById(int id)
//    {
//      WishlistUnit wishunit = wishListUnit.GetById(id);
//      DTOWishListUnit dTOUnit = new DTOWishListUnit()
//      {
//        Id = wishunit.Id,
//        WihslistId = wishunit.WihslistId,
//        UnitId = wishunit.UnitId,
//        user_Id = wishunit.wishlist.user.Id,
//        UserName = wishunit.wishlist.user.UserName,
//        unit = wishunit.unit,
//        wishlist = wishunit.wishlist,

//      };
//      return Ok(dTOUnit);





//    }
//    [HttpPost]
//    public ActionResult<DTOResult> AddWishlistUnit(WishlistUnit wish)
//    {

//      if (!ModelState.IsValid) return BadRequest(ModelState);
//      else
//      {
//        wishListUnit.insert(wish);
//        wishListUnit.save();
//        return CreatedAtAction("GetWishUnitById", new { id = wish.Id }, wish);
//      }


//    }


//    [HttpPut("{id}")]
//    public ActionResult<DTOResult> EditWishlistUnit(WishlistUnit list, int id)
//    {

//      if (list.Id != id) return BadRequest();
//      wishListUnit.update(list);
//      wishListUnit.save();

//      return NoContent();
//    }
//    [HttpDelete("{id}")]
//    public ActionResult<DTOResult> DeleteWishlistUnit(int id)
//    {
//      WishlistUnit w = wishListUnit.GetById(id);
//      if (w == null) return NotFound();
//      wishListUnit.Delete(id);
//      wishListUnit.save();
//      return Ok(w);
//    }

//  }
//}


