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
        private readonly ICompound _compound;

        private readonly IMapper _mapper;

        public ServicesCompoundController(IServicesCompound _AmmenitiesCompound, ICompound _compound, IMapper _mapper)
        {
            this._ammenitiesCompound = _AmmenitiesCompound;
            this._compound = _compound;
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

        //

        [HttpGet("GetInformationNeeded")]
        public ActionResult<DTOResult> GetInformationNeeded(int id)
        {
            Compound compounds = _compound.GetById(id);

            DTOCompound dTOCompound = _mapper.Map<DTOCompound>(compounds);
            List<DTOServicesCompound> Needed_Info = new List<DTOServicesCompound>() { };
               // dTOCompound.servicesCompounds;
            int a = 0;
            foreach(var x in compounds.servicesCompounds)
            {
                DTOServicesCompound  zz=new DTOServicesCompound ()
                {
                    Id=x.Id,
                    Service_Name=x.services.Name,
                    Service_Description=x.services.Description,
                    Compound_Name=x.compound.Name,
                };
                Needed_Info.Add(zz);
            }


            //List<ServicesCompound> servicesCompounds = _ammenitiesCompound.GetAll();
            //List<DTOServicesCompound> DTOAmmenitiesCompounds = servicesCompounds.Select(item => _mapper.Map<DTOServicesCompound>(item)).ToList();
            //foreach (var dtoAmmenitiesCompound in DTOAmmenitiesCompounds)
            //{
            //    //dtoCompound.bulidingComponents = _compoundbuilding.GetUnitComponents(dtoCompound.Id)
            //    //    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            //}
            DTOResult result = new DTOResult();
            if (Needed_Info == null ) result.IsPass = false;
            else result.IsPass = true;
            result.Data = Needed_Info;
            return result;
        }









        //

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
