using AutoMapper;
using BussienesLayer.DTO;
using Compound_project.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly Icomponent _component;
        private readonly IMapper _mapper;

        public ComponentController(Icomponent _component,IMapper _mapper)
        {
            this._component = _component;
            this._mapper = _mapper;
        }
        [HttpGet("GetAll")]
        public ActionResult<DTOResult> GetAll()
        {
            List<CComponent> components = _component.GetAll();
            List<DTOComponent> dTOComponent=
               components.Select(item => _mapper.Map<DTOComponent>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass= dTOComponent.Count!=0?true:false;
            result.Data = dTOComponent;
            return result;
        }
        [HttpDelete("DeleteComponent/{id}")]
        public ActionResult<DTOResult> DeleteComponent(int id)
        {
            DTOResult result = new DTOResult();
            CComponent component = _component.GetById(id);
            if(component!=null)
            {
                _component.Delete(id);
                _component.save();
                result.IsPass=true;
                result.Data = "Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Component Not Found ";
            }
            return result;
        }
    }
}
