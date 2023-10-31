﻿using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Mvc;
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
                //dtoCompound.buildings = _compoundbuilding.GetUnitComponents(dtoCompound.Id)
                //    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            if (dTOCompounds == null || dTOCompounds.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = dTOCompounds;
            return result;
        }
        [HttpPost("NewCompound")]
         public ActionResult<DTOResult> NewCompound (DTOCompound newcompound)
        {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                try
                {
                    Compound compound = _mapper.Map<Compound>(newcompound);
                    _compound.insert(compound);
                    _compound.save();
                    result.IsPass = true;
                    result.Data = $"Created unit with ID {compound.Id}";
                }
                catch(Exception ex)
                {
                    result.IsPass = false;
                    result.Data = "An error occurred while Adding the Compound";
                }
                
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
