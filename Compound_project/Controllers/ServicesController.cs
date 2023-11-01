using AutoMapper;
using BussienesLayer.DTO;
using BussienesLayer.Reposatories;
using Compound_project.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("GetAllAmmenities")]
        public ActionResult<DTOResult> GetAllAmmenities()
        {
            List<Service> service = _services.GetAll();
            List<DTOServices> dTOAmmenities = service.Select(item => _mapper.Map<DTOServices>(item)).ToList();
            //foreach (var dtoAmmenitiesCompound in dTOAmmenities)
            //{
                //dtoCompound.bulidingComponents = _compoundbuilding.GetUnitComponents(dtoCompound.Id)
                //    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            //}
            DTOResult result = new DTOResult();
            if (dTOAmmenities == null || dTOAmmenities.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = dTOAmmenities;
            return result;
        }

        //[HttpPost("InsertService")]
        //public ActionResult<DTOResult> InsertService(DTOServices dTOServices)
        //{
        //    DTOResult result = new DTOResult();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {

        //            Service service = _services.GetbyName(dTOServices.Name);
        //            if (service == null)
        //            {
        //                service = new Service() { Name = dTOServices.Name };
        //                _services.insert(service);
        //                _services.save();
        //                dTOServices.Id = service.Id;
        //            }
        //            else
        //                dTOServices.Id = service.Id;
        //            Service Ser = _mapper.Map<Service>(dTOServices);
        //            _services.insert(Ser);
        //            _services.save();
        //            result.IsPass = true;
        //            result.Data = $"Created Service with ID {Ser.Id}";

        //        }
        //        catch (Exception ex)
        //        {

        //            result.IsPass = false;
        //            result.Data = $"An error occurred while creating the service.";
        //        }


        //    }
        //    else
        //    {
        //        result.IsPass = false;
        //        result.Data = ModelState.Values.SelectMany(v => v.Errors)
        //            .Select(e => e.ErrorMessage).ToList();
        //    }
        //    return result;
        //}
        //[HttpPut("EditService/{id}")]
        //public ActionResult<DTOResult> EditUnitComponent(int id, DTOServices dTOServices)
        //{
        //    DTOResult result = new DTOResult();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Service service = _services.GetbyName(dTOServices.Name);
        //            if (service == null)
        //            {
        //                service = new Service() { Name = dTOServices.Name };
        //                _services.insert(service);
        //                _services.save();
        //                dTOServices.Id = service.Id;
        //            }
        //            else
        //                dTOServices.Id = service.Id;
        //            Service ser = _services.GetById(id);
        //            if (ser != null)
        //            {
        //                _mapper.Map(dTOServices, ser);
        //                _services.update(ser);
        //                _services.save();
        //                result.IsPass = true;
        //                result.Data = "Updated";
        //            }
        //            else
        //            {
        //                result.IsPass = false;
        //                result.Data = "Service Not Found";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            result.IsPass = false;
        //            result.Data = "An error occurred during update ";

        //        }
        //    }
        //    else
        //    {
        //        result.IsPass = false;
        //        result.Data = ModelState.Values.SelectMany(v => v.Errors)
        //            .Select(e => e.ErrorMessage).ToList();
        //    }
        //    return result;
        //}
    


        [HttpDelete("RemoveAmmenities")]
        public ActionResult<DTOResult> RemoveAmmenities(int id)
        {
            var result = new DTOResult();
            Service deleted_object = _services.GetById(id);
            if (deleted_object != null)
            {
                _services.Delete(id);
                _services.save();
                result.IsPass = true;
                result.Data ="deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "not found";

            }
            
            return result;

        }

        [HttpPut("EditAmenities")]
        public ActionResult<DTOResult> EditAmenities([FromBody] DTOServices? newamenities, int id)
        {
            Service oldCompound = _services.GetById(id);
            var result = new DTOResult();

            _mapper.Map(newamenities, oldCompound);


            if (newamenities.Id == null) result.IsPass = false;
            else result.IsPass = true;
            _services.update(oldCompound);
           _services.save();
            result.Data = newamenities;
            return Ok(result);

        }

        [HttpPost("NewAmmenities")]
        public ActionResult<DTOResult> NewAmmenities([FromBody] DTOServices? newammenities)
        {
            DTOResult result = new DTOResult();
            Service com = _mapper.Map<Service>(newammenities);

            if (ModelState.IsValid)
            {
                if (com == null) result.IsPass = false;
                else result.IsPass = true;
                result.Data = com;
                _services.insert(com);
                _services.save();
                //return Ok(result.Data);
            }
            else
            {
                result.Data = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            }

            return result;
        }
    }
}
