using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesBuildingController : ControllerBase
    {


        private readonly IServicesBuilding _servicebuilding;
        private readonly IMapper _mapper;
        private readonly IServices _services;

        public ServicesBuildingController(IServicesBuilding _servicebuilding, IMapper _mapper, IServices _services)
        {
            this._servicebuilding = _servicebuilding;
            this._mapper = _mapper;
            this._services = _services;
        }

   
        [HttpGet("GetServicesBuildingByBuilding/{id}")]
        public ActionResult<DTOResult> GetServicesBuildingByBuilding(int id)
        {
            List<ServiceBuilding> serviceBuildings = _servicebuilding.GetServiceBuilding(id);
            List<DTOServicesBuilding> dTOServicesBuildings =
                serviceBuildings.Select(item => _mapper.Map<DTOServicesBuilding>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dTOServicesBuildings.Count != 0 ? true : false;
            result.Data = dTOServicesBuildings;
            return result;
        }
        [HttpGet("GetServiceBuilding/{id}")]
        public ActionResult<DTOResult> GetServiceBuilding(int id)
        {
            DTOResult result = new DTOResult();
            ServiceBuilding serviceBuilding = _servicebuilding.GetById(id);
            DTOServicesBuilding dTOServicesBuilding = _mapper.Map<DTOServicesBuilding>(serviceBuilding);
            result.IsPass = dTOServicesBuilding != null ? true : false;
            result.Data = dTOServicesBuilding;
            return result;
        }

        [HttpPost("Insertbuildingservice")]
        public ActionResult<DTOResult> Insertbuildingservice(DTOServicesBuilding dTOservicsbuilding)
        {
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {

                    Service serv = _services.GetbyName(dTOservicsbuilding.Name);
                    if (serv == null)
                    {
                        serv = new Service() { Name = dTOservicsbuilding.Name ,Description = dTOservicsbuilding.Description };
                        _services.insert(serv);
                        _services.save();
                        dTOservicsbuilding.ServiceId = serv.Id;
                    }
                    else
                        dTOservicsbuilding.ServiceId = serv.Id;
                    ServiceBuilding servicebuilding = _mapper.Map<ServiceBuilding>(dTOservicsbuilding);
                    _servicebuilding.insert(servicebuilding);
                    _servicebuilding.save();
                    result.IsPass = true;
                    result.Data = $"Created ServiceCompound with ID {servicebuilding.Id}";

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

        [HttpPut("EditbuildingService/{id}")]
        public ActionResult<DTOResult> EditbuildingService(int id, DTOServicesBuilding dTOservicsbuilding)
        {
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {
                    Service serv = _services.GetbyName(dTOservicsbuilding.Name);
                    if (serv == null)
                    {
                        serv = new Service() { Name = dTOservicsbuilding.Name, Description = dTOservicsbuilding.Description };
                        _services.insert(serv);
                        _services.save();
                        dTOservicsbuilding.ServiceId = serv.Id;
                    }
                    else
                    {
                        dTOservicsbuilding.ServiceId = serv.Id;
                        if (serv.Description.ToLower() != dTOservicsbuilding.Description.ToLower())
                        {
                            serv.Description = dTOservicsbuilding.Description;
                            _services.update(serv);
                            _services.save();
                        }
                    }
                    ServiceBuilding servicebuilding = _servicebuilding.GetById(id);
                    if (servicebuilding != null)
                    {
                        _mapper.Map(dTOservicsbuilding, servicebuilding);
                        _servicebuilding.update(servicebuilding);
                        _servicebuilding.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "Service building Not Found";
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

        [HttpDelete("DeleteBuildingServices/{id}")]
        public ActionResult<DTOResult> DeleteBuildingServices(int id)
        {
            DTOResult result = new DTOResult();
            ServiceBuilding serviceBuilding = _servicebuilding.GetById(id);
            if (serviceBuilding != null)
            {
                _servicebuilding.Delete(id);
                _servicebuilding.save();
                result.IsPass = true;
                result.Data = "Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Service Building Not Found";
            }
            return result;
        }











    }
}
