using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServices _services;
        private readonly IMapper _mapper;

        public ServicesController(IServices _services, IMapper _mapper)
        {
            this._services = _services;
            this._mapper = _mapper;
        }

        [HttpGet("GetAllServices")]
        public ActionResult<DTOResult> GetAllServices()
        {
            List<Service> service = _services.GetAll();
            List<DTOServices> dTOServices = service.Select(item => _mapper.Map<DTOServices>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dTOServices.Count != 0 ? true : false;
            result.Data = dTOServices;
            return result;
        }

        [HttpDelete("DeleteServices/{id}")]
        public ActionResult<DTOResult> DeleteServices(int id)
        {
            var result = new DTOResult();
            Service service = _services.GetById(id);
            if (service != null)
            {
                _services.Delete(id);
                _services.save();
                result.IsPass = true;
                result.Data ="Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Not Found";

            }
            return result;
        }

    }
}
