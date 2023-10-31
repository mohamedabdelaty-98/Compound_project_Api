using AutoMapper;
using BussienesLayer.DTO;
using Compound_project.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesBuildingController : ControllerBase
    {


        private readonly IServicesBuilding _ammenitiesBuilding;
        private readonly IMapper _mapper;

        public ServicesBuildingController(IServicesBuilding _AmmenitiesBuilding, IMapper _mapper)
        {
            this._ammenitiesBuilding = _AmmenitiesBuilding;
            this._mapper = _mapper;
        }

        [HttpGet("GetAllAmmenitiesBuilding")]
        public ActionResult<DTOResult> GetAllAmmenitiesBuilding()
        {
            List<ServiceBuilding> servicesBuilsings = _ammenitiesBuilding.GetAll();
            List<DTOServicesBuilding> DTOAmmenitiesBuildingss = servicesBuilsings.
                Select(item => _mapper.Map<DTOServicesBuilding>(item)).ToList();
            foreach (var dtoAmmenitiesCompound in DTOAmmenitiesBuildingss)
            {
                //dtoCompound.bulidingComponents = _compoundbuilding.GetUnitComponents(dtoCompound.Id)
                //    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            if (DTOAmmenitiesBuildingss == null || DTOAmmenitiesBuildingss.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = DTOAmmenitiesBuildingss;
            return result;
        }



        [HttpPost("NewAmmenitiesBuilding")]
        public ActionResult<DTOResult> NewAmmenitiesBuilding([FromBody] DTOServicesBuilding? newammenitiesBuilding)
        {
            DTOResult result = new DTOResult();
            ServiceBuilding com = _mapper.Map<ServiceBuilding>(newammenitiesBuilding);

            if (ModelState.IsValid)
            {
                if (com == null) result.IsPass = false;
                else result.IsPass = true;
                result.Data = com;
                _ammenitiesBuilding.insert(com);
                _ammenitiesBuilding.save();
                //return Ok(result.Data);
            }
            else
            {
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
            result.Data = _ammenitiesBuilding.GetById(id);
            _ammenitiesBuilding.Delete(id);
            _ammenitiesBuilding.save();
            //Compound c = _compound.GetById(id);
            return Ok(result);

        }



        [HttpPut]
        public ActionResult<DTOResult> EditAmmenitiesBuilding([FromBody] DTOServicesCompound? newamenitiesbuilding)
        {
            ServiceBuilding oldCompound = _ammenitiesBuilding.GetById(newamenitiesbuilding.Id);
            var result = new DTOResult();

            _mapper.Map(newamenitiesbuilding, oldCompound);

            _ammenitiesBuilding.update(oldCompound);
            _ammenitiesBuilding.save();
            if (newamenitiesbuilding.Id == null) result.IsPass = false;
            else result.IsPass = true;
            result.Data = newamenitiesbuilding;
            return Ok(result);

        }







    }
}
