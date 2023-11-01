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

        [HttpGet("GetAllAmmenitiesCompound")]
        public ActionResult<DTOResult> GetAllAmmenitiesCompound()
        {
            List<ServiceUnit> servicesUnit = _serviceunit.GetAll();
            List<DTOServicesUnit> DTOAmmenitiesUnits = servicesUnit.Select(item => _mapper.Map<DTOServicesUnit>(item)).ToList();
            foreach (var dtoAmmenitiesCompound in DTOAmmenitiesUnits)
            {
                //dtoCompound.bulidingComponents = _compoundbuilding.GetUnitComponents(dtoCompound.Id)
                //    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            if (DTOAmmenitiesUnits == null || DTOAmmenitiesUnits.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = DTOAmmenitiesUnits;
            return result;
        }

        [HttpPost("Insertbuildingservice")]
        public ActionResult<DTOResult> Insertbuildingservice(DTOServicesUnit dTOservicsunit)
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

        [HttpPut("EditbuildingService/{id}")]
        public ActionResult<DTOResult> EditbuildingService(int id, DTOServicesUnit dTOservicsunit)
        {
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
                try
                {
                    Service serv = _serviceunit.GetbyName(dTOservicsunit.Name);
                    if (serv == null)
                    {
                        serv = new Service() { Name = dTOservicsunit.Name ,Description = dTOservicsunit.Description };
                        _services.insert(serv);
                        _services.save();
                        dTOservicsunit.ServiceId = serv.Id;
                    }
                    else
                        dTOservicsunit.ServiceId = serv.Id;
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





        [HttpDelete("RemoveAmmenitiesUnit")]
        public ActionResult<DTOResult> RemoveAmmenitiesUnit(int id)
        {
            var result = new DTOResult();
            if (id == null) result.IsPass = false;
            else result.IsPass = true;
            result.Data = _serviceunit.GetById(id);
            _serviceunit.Delete(id);
            _serviceunit.save();
            //Compound c = _compound.GetById(id);
            return Ok(result);

        }

        //[HttpPut("EditAmmenitiesUnit")]
        //public ActionResult<DTOResult> EditAmmenitiesUnit([FromBody] DTOServicesUnit? newamenitiesUnit)
        //{
        //    ServiceUnit oldCompound = _ammenitiesUnit.GetById(newamenitiesUnit.Id);
        //    var result = new DTOResult();

        //    _mapper.Map(newamenitiesUnit, oldCompound);

        //    _ammenitiesUnit.update(oldCompound);
        //    _ammenitiesUnit.save();
        //    if (newamenitiesUnit.Id == null) result.IsPass = false;
        //    else result.IsPass = true;
        //    result.Data = newamenitiesUnit;
        //    return Ok(result);

        //}


        //[HttpPost("NewAmmenitiesUnit")]
        //public ActionResult<DTOResult> NewAmmenitiesUnit([FromBody] DTOServicesUnit? newammenitiesUnit)
        //{
        //    DTOResult result = new DTOResult();
        //    ServiceUnit com = _mapper.Map<ServiceUnit>(newammenitiesUnit);

        //    if (ModelState.IsValid)
        //    {
        //        if (com == null) result.IsPass = false;
        //        else result.IsPass = true;
        //        result.Data = com;
        //        _ammenitiesUnit.insert(com);
        //        _ammenitiesUnit.save();
        //        //return Ok(result.Data);
        //    }
        //    else
        //    {
        //        result.Data = ModelState.Values.SelectMany(v => v.Errors)
        //            .Select(e => e.ErrorMessage).ToList();
        //    }

        //    return result;
        //}

    }
}
