using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Mvc;
using System.Data;
namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesCompoundController : ControllerBase
    {
        private readonly IServicesCompound _serviceCompound;
        private readonly IMapper _mapper;
        private readonly IServices _services;

        public ServicesCompoundController(IServicesCompound _serviceCompound, IMapper _mapper,IServices _services)
        {
            this._serviceCompound = _serviceCompound;
            this._mapper = _mapper;
            this._services = _services;
        }

        [HttpGet("GetServicesCompoundByCompound/{id}")]
        public ActionResult<DTOResult> GetServicesCompoundByCompound(int id)
        {
            List<ServicesCompound> servicesCompounds = _serviceCompound.GetServicesCompound(id);
            List<DTOServicesCompound> dTOServicesCompounds =
                servicesCompounds.Select(item => _mapper.Map<DTOServicesCompound>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dTOServicesCompounds.Count != 0 ? true : false;
            result.Data = dTOServicesCompounds;
            return result;
        }

        [HttpGet("GetServiceCompound/{id}")]
        public ActionResult<DTOResult> GetServiceCompound(int id)
        {
            DTOResult result = new DTOResult();
            ServicesCompound servicesCompound = _serviceCompound.GetById(id);
            DTOServicesCompound dTOServicesCompound = _mapper.Map<DTOServicesCompound>(servicesCompound);
            result.IsPass = dTOServicesCompound != null ? true : false;
            result.Data = dTOServicesCompound;
            return result;
        }

        [HttpPost("Insertcompoundservice")]
        public ActionResult<DTOResult> Insertcompoundservice(DTOServicesCompound dTOservicscompound)
        {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                try
                {

                    Service serv = _services.GetbyName(dTOservicscompound.Name);
                    if (serv == null)
                    {
                        serv = new Service() { Name = dTOservicscompound.Name, Description = dTOservicscompound.Description,IConName=dTOservicscompound.IConName };
                        _services.insert(serv);
                        _services.save();
                        dTOservicscompound.ServiceId = serv.Id;
                    }
                    else
                        dTOservicscompound.ServiceId = serv.Id;

                    ServicesCompound serviceCompound = _mapper.Map<ServicesCompound>(dTOservicscompound);
                    _serviceCompound.insert(serviceCompound);
                    _serviceCompound.save();
                    result.IsPass = true;
                    result.Data = $"Created ServiceCompound with ID {serviceCompound.Id}";
                }
                catch (Exception ex)
                {

                    result.IsPass = false;
                    result.Data = $"An error occurred while creating the Service Compound.";
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

        [HttpPut("EditcompoundService/{id}")]
        public ActionResult<DTOResult> EditcompoundService(int id, DTOServicesCompound dTOservicscompound)
        {
          
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
            {
                
                    Service serv = _services.GetbyName(dTOservicscompound.Name);
                    if (serv == null)
                    {
                        serv = new Service() { Name = dTOservicscompound.Name, Description = dTOservicscompound.Description,IConName=dTOservicscompound.IConName };
                        _services.insert(serv);
                        _services.save();
                        dTOservicscompound.ServiceId = serv.Id;
                    }
                    else
                    {
                        dTOservicscompound.ServiceId = serv.Id;
                        if (serv.Description.ToLower() != dTOservicscompound.Description.ToLower())
                        {
                            serv.Description = dTOservicscompound.Description;
                            _services.update(serv);
                            _services.save();
                        }
                    }
                    ServicesCompound serviceCompound = _serviceCompound.GetById(id);
                    if (serviceCompound != null)
                    {
                        _mapper.Map(dTOservicscompound, serviceCompound);
                        _serviceCompound.update(serviceCompound);
                        _serviceCompound.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "ServiceCompound Not Found";
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


        [HttpDelete("DeleteCompoundServices/{id}")]
        public ActionResult<DTOResult> DeleteCompoundServices(int id)
        {
            DTOResult result = new DTOResult();
            ServicesCompound servicesCompound = _serviceCompound.GetById(id);
            if (servicesCompound != null)
            {
                _serviceCompound.Delete(id);
                _serviceCompound.save();
                result.IsPass = true;
                result.Data = "Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Service Compound Not Found";
            }
            return result;
        }
    }
}
