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
    public class ServicesController : ControllerBase
    {
        private readonly ICompound _compound;

        private readonly IServices _ammenities;
        private readonly IMapper _mapper;

        public ServicesController(IServices _Ammenities, ICompound _Compound, IMapper _mapper)
        {
            this._compound = _Compound;
            this._ammenities = _Ammenities;
            this._mapper = _mapper;
        }

        [HttpGet("GetAllAmmenities")]
        public ActionResult<DTOResult> GetAllAmmenities()
        {
            List<Service> service = _ammenities.GetAll();
            List<DTOServices> dTOAmmenities = service.Select(item => _mapper.Map<DTOServices>(item)).ToList();
            //foreach (var dtoAmmenitiesCompound in dTOAmmenities)
            //{
                //dtoCompound.bulidingComponents = _compoundbuilding.GetUnitComponents(dtoCompound.Id)
                //    .Select(c => _mapper.Map<DTOUnitComponent>(c)).ToList();
            //}
            DTOResult result = new DTOResult();
            if (dTOAmmenities == null || dTOAmmenities.Count == 0) result.IsPass = false;
            else result.IsPass = true;
            result.Data = dTOAmmenities;
            return result;
        }
        
        








        [HttpPost("NewAmmenities")]
        public ActionResult<DTOResult> NewAmmenities([FromBody] DTOServices? newammenities)
        {
            DTOResult result = new DTOResult();
            Service com = _mapper.Map<Service>(newammenities);

            if (ModelState.IsValid)
            {
                if (com == null) result.IsPass = false;
                else result.IsPass = true;
                result.Data = com;
                _ammenities.insert(com);
                _ammenities.save();
                //return Ok(result.Data);
            }
            else
            {
                result.Data = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            }

            return result;
        }


        [HttpDelete("RemoveAmmenities")]
        public ActionResult<DTOResult> RemoveAmmenities(int id)
        {
            var result = new DTOResult();
            Service deleted_object = _ammenities.GetById(id);
            if (deleted_object != null)
            {
                _ammenities.Delete(id);
                _ammenities.save();
                result.IsPass = true;
                result.Data ="deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "not found";

            }
            
            return result;

        }

        [HttpPut("EditAmenities")]
        public ActionResult<DTOResult> EditAmenities([FromBody] DTOServices? newamenities,int id)
        {
            Service oldCompound = _ammenities.GetById(id);
            var result = new DTOResult();

            _mapper.Map(newamenities, oldCompound);

            
            if (newamenities.Id == null) result.IsPass = false;
            else result.IsPass = true;
            _ammenities.update(oldCompound);
            _ammenities.save();
            result.Data = newamenities;
            return Ok(result);

        }


    }
}
