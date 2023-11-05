using AutoMapper;
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
        private readonly IBuilding _building;

        public CompoundController(ICompound _Compound, IMapper _mapper,IBuilding _building)
        {
            this._compound= _Compound;
            this._mapper = _mapper;
            this._building = _building;
        }

        [HttpGet("GetAllCompounds")]
        public ActionResult<DTOResult> GetAllCompounds()
        {
            List<Compound> compounds = _compound.GetAll();
            List<DTOCompound> dTOCompounds = compounds.Select(item => _mapper.Map<DTOCompound>(item)).ToList();
            foreach (var dtoCompound in dTOCompounds)
            {
                dtoCompound.buildings = _building.FilterByCompoundNumber(dtoCompound.Id)
                   .Select(c => _mapper.Map<DTOBuilding>(c)).ToList();
            }
            DTOResult result = new DTOResult();
            result.IsPass = dTOCompounds.Count != 0 ? true : false;
            result.Data = dTOCompounds;
            return result;
        }
        [HttpPost("NewCompound")]
        public async Task<ActionResult<DTOResult>> NewCompound ([FromForm] DTOCompound newcompound)
        {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                try
                {
                    var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(),"Uploads");
                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }
                    var fileName = $"{Guid.NewGuid()}_{newcompound.File.FileName}";
                    var filePath = Path.Combine(uploadDirectory,fileName);
                    var fileExtension = Path.GetExtension(newcompound.File.FileName);

                    using ( var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await newcompound.File.CopyToAsync(stream);
                    }
                    Compound compound = _mapper.Map<Compound>(newcompound);
                    compound.File = filePath;

                    _compound.insert(compound);
                    _compound.save();
                    result.IsPass = true;
                    result.Data = $"Created Compound with ID {compound.Id}";
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

            if (deletedCompound == null) 
            { result.IsPass = false;result.Data = "Not Found"; }
            else
            {
                _compound.Delete(id);
                _compound.save();
                result.IsPass = true;
                result.Data = "Deleted";
            }
         
            return result;

        }

       
        [HttpPut("EditCompound")]
        public ActionResult<DTOResult> EditCompound([FromBody] DTOCompound? newcompound)
        {
            var result = new DTOResult();
            if(ModelState.IsValid)
            {
                try
                {
                    Compound oldCompound = _compound.GetById(newcompound.Id);
                    if (oldCompound != null)
                    {
                        _mapper.Map(newcompound, oldCompound);
                        _compound.update(oldCompound);
                        _compound.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "Unit not found";
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


    }
}
