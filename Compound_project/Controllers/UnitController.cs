using AutoMapper;
using BussienesLayer.Reposatories;
using Compound_project.AutoMapper;
using Compound_project.DTO;
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
            if (dTOUnits == null || dTOUnits.Count == 0) result.IsPass = false;
            else result.IsPass = true;
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
            if (dTOUnits == null || dTOUnits.Count == 0) result.IsPass = false;
            else result.IsPass=true;
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
            if (dTOUnits == null || dTOUnits.Count == 0) result.IsPass = false;
            else result.IsPass = true;
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
            if (dTOUnits == null || dTOUnits.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = dTOUnits;
            return result;
        }
    }
}
