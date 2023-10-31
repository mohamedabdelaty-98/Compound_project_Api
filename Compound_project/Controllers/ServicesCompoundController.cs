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
        private readonly IServicesCompound _ammenitiesCompound;
        private readonly IMapper _mapper;

        public ServicesCompoundController(IServicesCompound _AmmenitiesCompound, IMapper _mapper)
        {
            this._ammenitiesCompound = _AmmenitiesCompound;
            this._mapper = _mapper;
        }

        [HttpGet("GetAllAmmenitiesCompound")]
        public ActionResult<DTOResult> GetAllAmmenitiesCompound()
        {
            List<ServicesCompound> servicesCompounds = _ammenitiesCompound.GetAll();
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



        [HttpPost("NewAmmenitiesCompound")]
        public ActionResult<DTOResult> NewAmmenitiesCompound([FromBody] DTOServicesCompound? newammenitiesCompound)
        {
            DTOResult result = new DTOResult();
            ServicesCompound com = _mapper.Map<ServicesCompound>(newammenitiesCompound);

            if (ModelState.IsValid)
            {
                if (com == null) result.IsPass = false;
                else result.IsPass = true;
                result.Data = com;
                _ammenitiesCompound.insert(com);
                _ammenitiesCompound.save();
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
            result.Data = _ammenitiesCompound.GetById(id);
            _ammenitiesCompound.Delete(id);
            _ammenitiesCompound.save();
            //Compound c = _compound.GetById(id);
            return Ok(result);

        }



        [HttpPut]
        public ActionResult<DTOResult> EditCompound([FromBody] DTOServicesCompound? newamenitiescompound)
        {
            ServicesCompound oldCompound = _ammenitiesCompound.GetById(newamenitiescompound.Id);
            var result = new DTOResult();

            _mapper.Map(newamenitiescompound, oldCompound);

            _ammenitiesCompound.update(oldCompound);
            _ammenitiesCompound.save();
            if (newamenitiescompound.Id == null) result.IsPass = false;
            else result.IsPass = true;
            result.Data = newamenitiescompound;
            return Ok(result);

        }




    }
}
