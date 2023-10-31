using AutoMapper;
using BussienesLayer.DTO;
using Compound_project.Migrations;
using DataAccessLayer.Models;
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
   private readonly IMapper _mapper;

        public ApplicationController(IApplication App,IMapper _mapper)
        {
            this.App = App;
            this._mapper = _mapper;
        }
    [HttpGet("GetAllApplication")]
    public ActionResult<DTOResult>GetAllApplication()
    {
      List<Application>Apps = App.GetAll();
      List<DTOApplication> dTOApplications = Apps.Select(item => _mapper.Map<DTOApplication>(item)).ToList();
      DTOResult result = new DTOResult();
        result.IsPass = dTOApplications.Count != 0 ? true : false;
      result.Data = dTOApplications;
      return result;
    }
        [HttpGet("GetApplicaionsUser/{userId}")]
        public ActionResult<DTOResult> GetApplicaionsUser(string userId)
        {
            List<Application> applications = App.GetApplicationsByUserId(userId);
            List<DTOApplication> dTOApplications =
                applications.Select(item => _mapper.Map<DTOApplication>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass=dTOApplications.Count!=0? true : false;
            result.Data = dTOApplications;
            return result;

        }
        [HttpGet("GetApplicationById/{id}")]
    public ActionResult<DTOResult> GetApplicationById(int id)
    {
            Application application = App.GetById(id);
            DTOApplication dTOApplication = _mapper.Map<DTOApplication>(application);
            DTOResult result = new DTOResult();
            result.IsPass = dTOApplication != null ? true : false;
            result.Data = dTOApplication;
            return result;
    }
    [HttpPost("AddApplication")]
    public ActionResult<DTOResult> AddApplication(DTOApplication dTOApplication)
    {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                try
                {
                    Application application = _mapper.Map<Application>(dTOApplication);
                    App.insert(application);
                    App.save();
                    result.IsPass = true;
                    result.Data = $"Created unit with ID {application.Id}";
                }
                catch (Exception ex)
                {
                    result.IsPass = false;
                    result.Data = "An error occurred while creating the unit.";
                }
            }
            else
            {
                result.IsPass = false;
                result.Data = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            }

            return result;

        }
        [HttpPut("EditAPPlication/{id}")]
        public ActionResult<DTOResult> EditAPPlication(DTOApplication dTOApplication, int id)
        {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                try
                {
                    Application application = App.GetById(id);

                    if (application != null)
                    {
                        _mapper.Map(dTOApplication, application);
                        App.update(application);
                        App.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "Unit not found";
                    }
                }
                catch (Exception ex)
                {
                    result.IsPass = false;
                    result.Data = "An error occurred during update ";

                }

            }
            else
            {
                result.IsPass = false;
                result.Data = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            }

            return result;
        }
        [HttpDelete("DeleteApplication/{id}")]
        public ActionResult<DTOResult> DeleteApplication(int id)
        {
            DTOResult result = new DTOResult();
            Application application = App.GetById(id);
            if (application != null)
            {
                App.Delete(id);
                App.save();
                result.IsPass = true;
                result.Data = "Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Application Not Found";
            }
            return result;
        }
    }
}
