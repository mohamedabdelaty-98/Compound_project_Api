using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesUnitController : ControllerBase
    {


        private readonly IServicesUnit _serviceunit;
        private readonly IMapper _mapper;
        private readonly IServices _services;

        public ServicesUnitController(IServicesUnit _serviceunit, IMapper _mapper, IServices _services)
        {
            this._serviceunit = _serviceunit;
            this._mapper = _mapper;
            this._services = _services;
        }

        [HttpGet("GetServicesUnitByUnit/{id}")]
        public ActionResult<DTOResult> GetServicesUnitByUnit(int id)
        {
            List<ServiceUnit> serviceUnits = _serviceunit.GetServicesUnitByUint(id);
            List<DTOServicesUnit> dTOServicesUnits =
                serviceUnits.Select(item => _mapper.Map<DTOServicesUnit>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dTOServicesUnits.Count != 0 ? true : false;
            result.Data = dTOServicesUnits;
            return result;
        }

        [HttpGet("GetServiceUnit/{id}")]
        public ActionResult<DTOResult> GetServiceUnit(int id)
        {
            DTOResult result = new DTOResult();
            ServiceUnit serviceUnit = _serviceunit.GetById(id);
            DTOServicesUnit dTOServicesUnit = _mapper.Map<DTOServicesUnit>(serviceUnit);
            result.IsPass = dTOServicesUnit != null ? true : false;
            result.Data = dTOServicesUnit;
            return result;
        }

        [HttpPost("InsertUnitservice")]
        public ActionResult<DTOResult> InsertUnitservice(DTOServicesUnit dTOservicsunit)
        {
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {

                    Service serv = _services.GetbyName(dTOservicsunit.Name);
                    if (serv == null)
                    {
                        serv = new Service() { Name = dTOservicsunit.Name, Description = dTOservicsunit.Description };
                        _services.insert(serv);
                        _services.save();
                        dTOservicsunit.ServiceId = serv.Id;
                    }
                    else
                        dTOservicsunit.ServiceId = serv.Id;
                    ServiceUnit serviceunit = _mapper.Map<ServiceUnit>(dTOservicsunit);
                    _serviceunit.insert(serviceunit);
                    _serviceunit.save();
                    result.IsPass = true;
                    result.Data = $"Created ServiceCompound with ID {serviceunit.Id}";

                }
                catch (Exception ex)
                {

                    result.IsPass = false;
                    result.Data = $"An error occurred while creating the Service Unit.";
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

        [HttpPut("EditUnitService/{id}")]
        public ActionResult<DTOResult> EditUnitService(int id, DTOServicesUnit dTOservicsunit)
        {
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {
                    Service serv = _services.GetbyName(dTOservicsunit.Name);
                    if (serv == null)
                    {
                        serv = new Service() { Name = dTOservicsunit.Name ,Description = dTOservicsunit.Description };
                        _services.insert(serv);
                        _services.save();
                        dTOservicsunit.ServiceId = serv.Id;
                    }
                    else
                    {
                        dTOservicsunit.ServiceId = serv.Id;
                        if (serv.Description.ToLower() != dTOservicsunit.Description.ToLower())
                        {
                            serv.Description = dTOservicsunit.Description;
                            _services.update(serv);
                            _services.save();
                        }
                    }
                    ServiceUnit serviceunit = _serviceunit.GetById(id);
                    if (serviceunit != null)
                    {
                        _mapper.Map(dTOservicsunit, serviceunit);
                        _serviceunit.update(serviceunit);
                        _serviceunit.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "Service unit Not Found";
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

        [HttpDelete("DeleteUnitServices/{id}")]
        public ActionResult<DTOResult> DeleteUnitServices(int id)
        {
            DTOResult result = new DTOResult();
            ServiceUnit serviceUnit = _serviceunit.GetById(id);
            if (serviceUnit != null)
            {
                _serviceunit.Delete(id);
                _serviceunit.save();
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
