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
    public class CompoundController : ControllerBase
    {
        private readonly ICompound _compound;
        private readonly IMapper _mapper;

        public CompoundController(ICompound _Compound, IMapper _mapper)
        {
            this._compound= _Compound;
            this._mapper = _mapper;
        }
        [HttpGet("GetAllCompounds")]
        public ActionResult<DTOResult> GetAllCompounds()
        {
            List<Compound> compounds = _compound.GetAll();
            List<DTOCompound> dTOCompounds = compounds.Select(item => _mapper.Map<DTOCompound>(item)).ToList();
            foreach (var dtoCompound in dTOCompounds)
            {
                //dtoCompound.bulidingComponents = _compoundbuilding.GetUnitComponents(dtoCompound.Id)
                //    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            if (dTOCompounds == null || dTOCompounds.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = dTOCompounds;
            return result;
        }
        [HttpPost("NewCompound")]
         public ActionResult<DTOResult> NewCompound ([FromBody]DTOCompound? newcompound)
        {
            DTOResult result = new DTOResult();
            Compound com = _mapper.Map<Compound>(newcompound);

            if (ModelState.IsValid)
            {
                if (com == null) result.IsPass = false;
                else result.IsPass = true;
                result.Data = com;
                _compound.insert(com);
                _compound.save();
                //return Ok(result.Data);
            }
            else
            {
                result.Data = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            }
            
            return result;
        }
        [HttpDelete("RemoveCompound")]
        public ActionResult<DTOResult> RemoveCompound(int id)
        {
            var result = new DTOResult();
            Compound deletedCompound= _compound.GetById(id);

            if (deletedCompound == null) { result.IsPass = false; }
            else
            {
                _compound.Delete(id);
                _compound.save();
                result.IsPass = true;
                result.Data = "deleted";
            }
         
            return Ok(result);

        }

       
        [HttpPut]
        public ActionResult<DTOResult> EditCompound([FromBody] DTOCompound? newcompound)
        {
            Compound oldCompound = _compound.GetById(newcompound.Id);
            var result = new DTOResult();
          
            _mapper.Map(newcompound, oldCompound);

            _compound.update(oldCompound); 
            _compound.save();
            if (newcompound.Id == null) result.IsPass = false;
            else result.IsPass = true;
            result.Data = newcompound;
            return Ok(result);
            
        }


    }
}
