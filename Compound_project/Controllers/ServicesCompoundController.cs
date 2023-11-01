using AutoMapper;
using BussienesLayer.DTO;
using BussienesLayer.Reposatories;
using Compound_project.DTO;
using Compound_project.Migrations;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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

        [HttpGet("GetAllAmmenitiesCompound")]
        public ActionResult<DTOResult> GetAllAmmenitiesCompound()
        {
            List<ServicesCompound> servicesCompounds = _serviceCompound.GetAll();
            List<DTOServicesCompound> DTOAmmenitiesCompounds = servicesCompounds.Select(item => _mapper.Map<DTOServicesCompound>(item)).ToList();
            foreach (var dtoAmmenitiesCompound in DTOAmmenitiesCompounds)
            {
                //dtoCompound.bulidingComponents = _compoundbuilding.GetUnitComponents(dtoCompound.Id)
                //    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            if (DTOAmmenitiesCompounds == null || DTOAmmenitiesCompounds.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = DTOAmmenitiesCompounds;
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
                        serv = new Service() { Name = dTOservicscompound.Name, Description = dTOservicscompound.Description };
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
                        serv = new Service() { Name = dTOservicscompound.Name, Description = dTOservicscompound.Description };
                        _services.insert(serv);
                        _services.save();
                        dTOservicscompound.ServiceId = serv.Id;
                    }
                    else
                        dTOservicscompound.ServiceId = serv.Id;
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












        [HttpDelete("RemoveAmmenitiesCompound")]
        public ActionResult<DTOResult> RemoveAmmenitiesCompound(int id)
        {
            var result = new DTOResult();
            if (id == null) result.IsPass = false;
            else result.IsPass = true;
            result.Data = _serviceCompound.GetById(id);
            _serviceCompound.Delete(id);
            _serviceCompound.save();
            //Compound c = _compound.GetById(id);
            return Ok(result);

        }

        //public ActionResult<DTOResult> NewAmmenitiesCompound([FromBody] DTOServicesCompound? newammenitiesCompound)
        //{
        //    DTOResult result = new DTOResult();
        //    ServicesCompound com = _mapper.Map<ServicesCompound>(newammenitiesCompound);

        //    if (ModelState.IsValid)
        //    {
        //        if (com == null) result.IsPass = false;
        //        else result.IsPass = true;
        //        result.Data = com;
        //        _serviceCompound.insert(com);
        //        _serviceCompound.save();
        //        //return Ok(result.Data);
        //    }
        //    else
        //    {
        //        result.Data = ModelState.Values.SelectMany(v => v.Errors)
        //            .Select(e => e.ErrorMessage).ToList();
        //    }

        //    return result;
        //}

        //[HttpPut]
        //public ActionResult<DTOResult> EditCompound([FromBody] DTOServicesCompound? newamenitiescompound)
        //{
        //    ServicesCompound oldCompound = _ammenitiesCompound.GetById(newamenitiescompound.Id);
        //    var result = new DTOResult();

        //    _mapper.Map(newamenitiescompound, oldCompound);

        //    _ammenitiesCompound.update(oldCompound);
        //    _ammenitiesCompound.save();
        //    if (newamenitiescompound.Id == null) result.IsPass = false;
        //    else result.IsPass = true;
        //    result.Data = newamenitiescompound;
        //    return Ok(result);

        //}
    }
}
