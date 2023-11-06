using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuilding _building;
        private readonly IMapper _mapper;
        private readonly IUnit _unit;
       

        public BuildingController(IBuilding building, IMapper mapper, IUnit unit)
        {
            _building = building;
            _mapper = mapper;
            _unit = unit;
      
        }

        private DTOResult GetBuildingsCommonLogic(List<Building> buildings)
        {
            var dTOBuildings = buildings.Select(building => _mapper.Map<DTOBuilding>(building)).ToList();

            foreach (var building in dTOBuildings)
            {
                building.Units = _unit.FilterByBuildingNumber(building.BulidingNumber).Select(unit => _mapper.Map<DTOUnit>(unit)).ToList();
            }

            DTOResult result = new DTOResult();
            result.Data = dTOBuildings;
            result.IsPass = dTOBuildings.Count != 0 ? true : false;
            return result;
        }


        [HttpGet("GetAllBuilding")]
        public ActionResult<DTOResult> GetAllBuilding()
        {
            List<Building> buildings = _building.GetAll();
            DTOResult result = GetBuildingsCommonLogic(buildings);
            return result;
        }


        [HttpGet("BuildingsInCompound/{num}")]
        public ActionResult<DTOResult> BuildingsInCompound(int num)
        {
            List<Building> buildings = _building.FilterByCompoundNumber(num);
            DTOResult result = GetBuildingsCommonLogic(buildings);
            return result;
        }


        [HttpGet("BuildingsBasedUnitFloor/{num}")]
        public ActionResult<DTOResult> BuildingsBasedUnitFloor(int num)
        {
            List<Building> buildings = _building.FilterBasedOnUnitFloor(num);
            DTOResult result = GetBuildingsCommonLogic(buildings);
            return result;
        }


        [HttpGet("BuildingsUnitNumBedRooms/{num}")]
        public ActionResult<DTOResult> BuildingsUnitNumBedRooms(int num)
        {
            List<Building> buildings = _building.FilterBasedOnUnitNumBedRooms(num);
            DTOResult result = GetBuildingsCommonLogic(buildings);
            return result;
        }


        [HttpGet("BuildingsActive")]
        public ActionResult<DTOResult> BuildingsActive()
        {
            List<Building> buildings = _building.FilterByStatus();
            DTOResult result = GetBuildingsCommonLogic(buildings);
            return result;
        }


        [HttpGet("BuildingsUnitActive")]
        public ActionResult<DTOResult> BuildingsUnitActive()
        {
            List<Building> buildings = _building.FilterBasedOnUnitStatus();
            DTOResult result = GetBuildingsCommonLogic(buildings);
            return result;
        }

        //For Admin
       
        [HttpPost("AddBuilding")]
        public ActionResult<DTOResult> AddBuilding (DTOBuilding dTOBuilding)
        {
            DTOResult result = new DTOResult();
            if(ModelState.IsValid)
            {
                try
                {
                    Building building = _mapper.Map<Building>(dTOBuilding);
                    _building.insert(building);
                    _building.save();
                    result.IsPass = true;
                    result.Data = $"Created unit with ID {building.Id}";
                }
                catch (Exception ex)
                {
                    result.IsPass = false;
                    result.Data = "An error occurred while creating the Building.";
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

        [HttpGet("BuildingById/{id}")]
        public ActionResult<DTOResult> BuildingById(int id)
        {
            Building building = _building.GetById(id);
            DTOResult result = new DTOResult();

            if (building != null)
            {
                DTOBuilding dTOBuilding = _mapper.Map<DTOBuilding>(building);
                dTOBuilding.Units = _unit.FilterByBuildingNumber(id).Select(u => _mapper.Map<DTOUnit>(u)).ToList();
                result.Data = dTOBuilding;
                result.IsPass = true;

            }
            else
            {
                result.IsPass = false;
                result.Data = "Not Found";
            }
            return result;
        }


        [HttpPut("EditBuilding")]
        public ActionResult<DTOResult> EditBuilding (DTOBuilding dTOBuilding)
        {
            DTOResult result = new DTOResult();
            if(ModelState.IsValid)
            {
                try
                {
                    Building building = _building.GetById(dTOBuilding.Id);
                    if(building!=null)
                    {
                        _mapper.Map(building, dTOBuilding);
                        _building.update(building);
                        _building.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "Building not found";
                    }
                }
                catch(Exception ex)
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


        [HttpDelete("DeleteBuilding/{id}")]
        public ActionResult<DTOResult> DeleteBuilding (int id)
        {
            DTOResult result= new DTOResult();
            Building building = _building.GetById(id);

            if (building == null)
            {
                result.IsPass=false;
                result.Data = "Building not Found";
            }
            else
            {
                _building.Delete(id);
                _building.save();
                result.IsPass=true;
                result.Data = "Building Has been deleted successfully";
            }
            return result;

        }
    }
}
