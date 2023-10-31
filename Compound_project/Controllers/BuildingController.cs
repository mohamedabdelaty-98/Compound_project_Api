using AutoMapper;
using BussienesLayer.DTO;
using BussienesLayer.Reposatories;
using Compound_project.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            if (dTOBuildings != null || dTOBuildings.Count != 0) result.IsPass = true;
            else result.IsPass = false;
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


        [HttpGet("BuildingById/{id}")]
        public ActionResult<DTOResult> BuildingById (int id)
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


        [HttpPost("AddBuilding")]
        public ActionResult<DTOResult> AddBuilding (DTOBuilding building)
        {
            DTOResult result = new DTOResult();

            if (building == null)
            {
                result.IsPass = false;
                result.Data = "Please Fill The Data";

            }
            else
            {
                if (ModelState.IsValid)
                {
                    Building building1 = _mapper.Map<Building>(building);
                    _building.insert(building1);
                    try
                    {
                        _building.save();
                        result.IsPass = true;
                        result.Data = "Building has been added successfully";
                    }
                    catch
                    {
                        result.Data = ModelState;
                        result.IsPass= false;
                    }

                }
                else
                {
                    result.Data = ModelState;
                    result.IsPass = false;
                }
            }
            return result;
        }


        [HttpPut("EditBuilding")]
        public ActionResult<DTOResult> EditBuilding (DTOBuilding building)
        {
            DTOResult result = new DTOResult();
            if (building == null)
            {
                result.IsPass = false;
                result.Data = "Please Fill The Data";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Building b = _building.GetById(building.Id);
                    _mapper.Map(b, building);
                    _building.update(b);
                    _building.save();
                    result.IsPass = true;
                    result.Data = building;
                }
                else {
                    result.IsPass = false;
                    result.Data = "Please Enter a Valid Data";
                }
                
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
                result.Data = "Item Has been deleted successfully";
            }
            return result;

        }
    }
}
