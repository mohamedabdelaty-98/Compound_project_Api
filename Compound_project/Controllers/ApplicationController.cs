using BussienesLayer.DTO;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Mvc;
using Application = DataAccessLayer.Models.Application;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class ApplicationController : ControllerBase
  {
    private readonly IApplication App;

    public ApplicationController(IApplication App)
    {
      this.App = App;
    }
    [HttpGet]
    public ActionResult<DTOResult>GetAll()
    {
      List<Application>Apps = App.GetAll();
      List<DTOApplication> Applications = new List<DTOApplication>();
      foreach (Application app in Apps)

      {
        DTOApplication appDTO = new DTOApplication();
        {
          appDTO.Id = app.Id;
         appDTO.Name = app.Name;
          appDTO.SSN = app.SSN;
          appDTO.PhoneNumber = app.PhoneNumber;
          appDTO.ContactEmail = app.ContactEmail;
          appDTO.UserId = app.UserId;
        }
        Applications.Add(appDTO);

      }
      DTOResult result = new DTOResult();
      if (Applications == null || Applications.Count == 0) result.IsPass = false;
      else result.IsPass = true;
      result.Data = Applications;
      return result;



    }
    [HttpGet("id")]
    public ActionResult<DTOResult> GetApplicationById(int id)
    {
     Application application= App.GetById(id);
     DTOApplication appDTO = new DTOApplication()
     {
       Id = application.Id,
      SSN = application.SSN,
      Name = application.Name,
      PhoneNumber = application.PhoneNumber,
      UserId = application.UserId,
      ContactEmail = application.ContactEmail
    };
 
      return Ok(appDTO);


      

    }
    [HttpPost]
    public ActionResult<DTOResult> AddApplication(DTOApplication dTO)
    {
        Application application=new Application()
        {
          
          SSN = dTO.SSN,
          Name = dTO.Name,
          PhoneNumber = dTO.PhoneNumber,
          UserId = dTO.UserId,
          ContactEmail = dTO.ContactEmail

        };
      if (!ModelState.IsValid) return BadRequest(ModelState);
      else
      {
        App.insert(application);
        App.save();
       return CreatedAtAction("GetApplicationById", new {id=application.Id},application);
      }


    }
    [HttpPut("id")]
    public ActionResult<DTOResult> EditAPP(Application app,int id)
    {
     
      if(app.Id!=id) return BadRequest();
      App.update(app);
      App.save();
     
     return NoContent();
    }
    [HttpDelete ("id")]
    public ActionResult<DTOResult> DeleteAPP(int id)
    {
     Application app = App.GetById(id);
      if (app==null) return NotFound();
      App.Delete(id);
      App.save();
      return Ok(app);
    }

  }
}
