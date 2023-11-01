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
    public class ServicesUnitController : ControllerBase
    {


        private readonly IServicesUnit _ammenitiesUnit;
        private readonly IUnit _unit;

        private readonly IMapper _mapper;

        public ServicesUnitController(IServicesUnit _AmmenitiesUnit, IUnit _unit, IMapper _mapper)
        {
            this._ammenitiesUnit = _AmmenitiesUnit;
            this._unit = _unit;
            this._mapper = _mapper;
        }

        [HttpGet("GetAllAmmenitiesCompound")]
        public ActionResult<DTOResult> GetAllAmmenitiesCompound()
        {
            List<ServiceUnit> servicesUnit = _ammenitiesUnit.GetAll();
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

        //



        [HttpGet("GetInfomationNeeded")]
        public ActionResult<DTOResult> GetInfomationNeeded(int id)
        {

            Unit units = _unit.GetById(id);

            DTOUnit dTOCompound = _mapper.Map<DTOUnit>(units);
            List<DTOServicesUnit> Needed_Info = new List<DTOServicesUnit>() { };
            // dTOCompound.servicesCompounds;
            
            foreach (var x in units.serviceUnits)
            {
                DTOServicesUnit zz = new DTOServicesUnit()
                {
                    Id=x.Id,
                    Service_Name = x.service.Name,
                    Service_Description = x.service.Description,
                    Unit_Name = x.unit.UnitNumber
                };
                Needed_Info.Add(zz);
            }


            //List<ServiceUnit> servicesUnit = _ammenitiesUnit.GetAll();
            //List<DTOServicesUnit> DTOAmmenitiesUnits = servicesUnit.Select(item => _mapper.Map<DTOServicesUnit>(item)).ToList();
            //foreach (var dtoAmmenitiesCompound in DTOAmmenitiesUnits)
            //{
            //    //dtoCompound.bulidingComponents = _compoundbuilding.GetUnitComponents(dtoCompound.Id)
            //    //    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            //}
            DTOResult result = new DTOResult();
            if (Needed_Info == null || Needed_Info.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = Needed_Info;
            return result;
        }













        //


        [HttpPost("NewAmmenitiesUnit")]
        public ActionResult<DTOResult> NewAmmenitiesUnit([FromBody] DTOServicesUnit? newammenitiesUnit)
        {
            DTOResult result = new DTOResult();
            ServiceUnit com = _mapper.Map<ServiceUnit>(newammenitiesUnit);

            if (ModelState.IsValid)
            {
                if (com == null) result.IsPass = false;
                else result.IsPass = true;
                result.Data = com;
                _ammenitiesUnit.insert(com);
                _ammenitiesUnit.save();
                //return Ok(result.Data);
            }
            else
            {
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
            result.Data = _ammenitiesUnit.GetById(id);
            _ammenitiesUnit.Delete(id);
            _ammenitiesUnit.save();
            //Compound c = _compound.GetById(id);
            return Ok(result);

        }
        [HttpPut("EditAmmenitiesUnit")]
        public ActionResult<DTOResult> EditAmmenitiesUnit([FromBody] DTOServicesUnit? newamenitiesUnit)
        {
            ServiceUnit oldCompound = _ammenitiesUnit.GetById(newamenitiesUnit.Id);
            var result = new DTOResult();

            _mapper.Map(newamenitiesUnit, oldCompound);

            _ammenitiesUnit.update(oldCompound);
            _ammenitiesUnit.save();
            if (newamenitiesUnit.Id == null) result.IsPass = false;
            else result.IsPass = true;
            result.Data = newamenitiesUnit;
            return Ok(result);

        }




    }
}
