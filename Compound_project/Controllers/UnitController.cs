using AutoMapper;
using BussienesLayer.Reposatories;
using Compound_project.AutoMapper;
using Compound_project.DTO;
using Compound_project.Migrations;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnit _unit;
        private readonly IUnitComponent _unitComponent;
        private readonly IMapper _mapper;

        public UnitController(IUnit _unit,IUnitComponent _unitComponent,IMapper _mapper)
        {
            this._unit = _unit;
            this._unitComponent = _unitComponent;
            this._mapper = _mapper;
        }
        [HttpGet("GetAllUnit")]
        public ActionResult<DTOResult>GetAllUnit()
        {
            List<Unit> units = _unit.GetAll();
            List<DTOUnit> dTOUnits= units.Select(item => _mapper.Map<DTOUnit>(item)).ToList();
            foreach (var dtoUnit in dTOUnits)
            {
                dtoUnit.unitcomponents = _unitComponent.GetUnitComponents(dtoUnit.Id)
                    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            result.IsPass= dTOUnits.Count!=0? true:false;
            result.Data = dTOUnits;
            return result;
        }
        [HttpGet("UnitsActive")]
        public ActionResult<DTOResult> UnitsActive()
        {
            List<Unit> units = _unit.FilterByStatus();
            List<DTOUnit> dTOUnits= units.Select(item => _mapper.Map<DTOUnit>(item)).ToList();
            foreach (var dtoUnit in dTOUnits)
            {
                dtoUnit.unitcomponents = _unitComponent.GetUnitComponents(dtoUnit.Id)
                    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            result.IsPass = dTOUnits.Count != 0 ? true : false;
            result.Data = dTOUnits;
            return result;
        }
        [HttpGet("UnitsInFloor/{num}")]
        public ActionResult<DTOResult> UnitsInFloor(int num)
        {
            List<Unit> units = _unit.FilterByNumOfFloor(num);
            List<DTOUnit> dTOUnits = units.Select(item => _mapper.Map<DTOUnit>(item)).ToList();
            foreach (var dtoUnit in dTOUnits)
            {
                dtoUnit.unitcomponents = _unitComponent.GetUnitComponents(dtoUnit.Id)
                    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            result.IsPass = dTOUnits.Count != 0 ? true : false;
            result.Data = dTOUnits;
            return result;
        }
        [HttpGet("UnitInBuilding/{num}")]
        public ActionResult<DTOResult> UnitInBuilding(int num)
        {
            List<Unit> units = _unit.FilterByBuildingNumber(num);
            List<DTOUnit> dTOUnits = units.Select(item => _mapper.Map<DTOUnit>(item)).ToList();
            foreach (var dtoUnit in dTOUnits)
            {
                dtoUnit.unitcomponents = _unitComponent.GetUnitComponents(dtoUnit.Id)
                    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            result.IsPass=dTOUnits.Count!=0?true : false;
            result.Data = dTOUnits;
            return result;
        }
        [HttpGet("UnitHaveBedRoomsNumber/{num}")]
        public ActionResult<DTOResult> UnitHaveBedRoomsNumber(int num)
        {
            List<Unit> units = _unit.FilterByNumberOfRoom(num);
            List<DTOUnit> dTOUnits = units.Select(item => _mapper.Map<DTOUnit>(item)).ToList();
            foreach (var dtoUnit in dTOUnits)
            {
                dtoUnit.unitcomponents = _unitComponent.GetUnitComponents(dtoUnit.Id)
                    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            result.IsPass = dTOUnits.Count != 0 ? true : false;
            result.Data = dTOUnits;
            return result;
        }
        [HttpGet("UnitsFilterByAll/{FloorNum}/{BuildingNum}/{NumOfRoom}")]
        public ActionResult<DTOResult> UnitsFilterByAll(int FloorNum,int BuildingNum,int NumOfRoom)
        {
            List<Unit> units = _unit.FilterByAll(FloorNum,BuildingNum,NumOfRoom);
            List<DTOUnit> dTOUnits = units.Select(item => _mapper.Map<DTOUnit>(item)).ToList();
            foreach (var dtoUnit in dTOUnits)
            {
                dtoUnit.unitcomponents = _unitComponent.GetUnitComponents(dtoUnit.Id)
                    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            result.IsPass = dTOUnits.Count != 0 ? true : false;
            result.Data = dTOUnits;
            return result;
        }
       
       //For admin 
        [HttpPost("InsertUnit")]
        public ActionResult<DTOResult> InsertUnit(DTOUnit dTOUnit)
        {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                try
                {
                    Unit unit = _mapper.Map<Unit>(dTOUnit);
                    _unit.insert(unit);
                    _unit.save();
                    result.IsPass = true;
                    result.Data = $"Created unit with ID {unit.Id}";
                }
                catch (Exception ex)
                {
                    result.IsPass = false;
                    result.Data = $"An error occurred while creating the unit.";
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
        [HttpGet("GetUnit/{id}")]
        public ActionResult<DTOResult> GetUnit(int id)
        {
            Unit unit = _unit.GetById(id);
            DTOUnit dTOUnit = _mapper.Map<DTOUnit>(unit);
            DTOResult result = new DTOResult();
            result.IsPass = dTOUnit != null ? true : false;
            result.Data = dTOUnit;
            return result;

        }
        [HttpPut("EditUnit/{id}")]
        public ActionResult<DTOResult> EditUnit(int id, DTOUnit dTOUnit)
        {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                try
                {
                    Unit unit = _unit.GetById(id);

                    if (unit != null)
                    {
                        _mapper.Map(dTOUnit, unit);
                        _unit.update(unit);
                        _unit.save();
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

        [HttpDelete("DeleteUnit/{id}")]
        public ActionResult<DTOResult> DeleteUnit(int id)
        {
            DTOResult result = new DTOResult();
            Unit unit = _unit.GetById(id);
            if(unit != null)
            {
                _unit.Delete(id);
                _unit.save();
                result.IsPass = true;
                result.Data = "Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Unit Not Found";
            }
            return result;
        }
    }
}
