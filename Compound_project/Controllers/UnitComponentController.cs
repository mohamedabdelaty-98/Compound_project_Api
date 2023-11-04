using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitComponentController : ControllerBase
    {
        private readonly IUnitComponent _unitcomponent;
        private readonly IMapper _mapper;
        private readonly Icomponent _component;

        public UnitComponentController(IUnitComponent _unitcomponent,IMapper _mapper,
            Icomponent _component)
        {
            this._unitcomponent = _unitcomponent;
            this._mapper = _mapper;
            this._component = _component;
        }
        [HttpGet("GetunitComponentByUnitId/{id}")]
        public ActionResult<DTOResult> GetunitComponentByUnitId(int id)
        {
            List<UnitComponent> unitComponents = _unitcomponent.GetUnitComponents(id);
            List<DTOUnitComponent> dTOUnitComponents =
                unitComponents.Select(item => _mapper.Map<DTOUnitComponent>(item)).ToList();
            DTOResult result = new DTOResult();
            result.IsPass = dTOUnitComponents.Count != 0 ? true : false;
            result.Data = dTOUnitComponents;
            return result;

        }
        [HttpPost("InsertUnitComponent")]
        public ActionResult<DTOResult> InsertUnitComponent(DTOUnitComponent dTOUnitComponent)
        {
            DTOResult result = new DTOResult();
            if(ModelState.IsValid)
            {
                try
                {

                    CComponent component = _component.GetbyName(dTOUnitComponent.Name);
                    if (component == null)
                    {
                        component = new CComponent() { Name = dTOUnitComponent.Name };
                        _component.insert(component);
                        _component.save();
                        dTOUnitComponent.ComponentId = component.Id;
                    }
                    else
                        dTOUnitComponent.ComponentId = component.Id;
                    UnitComponent unitComponent = _mapper.Map<UnitComponent>(dTOUnitComponent);
                    _unitcomponent.insert(unitComponent);
                    _unitcomponent.save();
                    result.IsPass = true;
                    result.Data = $"Created unitComponent with ID {unitComponent.Id}";

                }
                catch (Exception ex)
                {

                    result.IsPass = false;
                    result.Data = $"An error occurred while creating the unitcomponent.";
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
        [HttpPut("EditUnitComponent/{id}")]
        public ActionResult<DTOResult> EditUnitComponent(int id,DTOUnitComponent dTOUnitComponent)
        {
            DTOResult result = new DTOResult();
            if(ModelState.IsValid)
            {
                try
                {
                    CComponent component = _component.GetbyName(dTOUnitComponent.Name);
                    if (component == null)
                    {
                        component = new CComponent() { Name = dTOUnitComponent.Name };
                        _component.insert(component);
                        _component.save();
                        dTOUnitComponent.ComponentId = component.Id;
                    }
                    else
                        dTOUnitComponent.ComponentId = component.Id;
                    UnitComponent unitComponent = _unitcomponent.GetById(id);
                    if(unitComponent!=null)
                    {
                        _mapper.Map(dTOUnitComponent, unitComponent);
                        _unitcomponent.update(unitComponent);
                        _unitcomponent.save();
                        result.IsPass = true;
                        result.Data = "Updated";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "UnitComponent Not Found";
                    }
                }
                catch (Exception ex)
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

        [HttpGet("GetUnitComponent/{id}")]
        public ActionResult<DTOResult> GetUnitComponent(int id)
        {
            DTOResult result = new DTOResult();
            UnitComponent unitComponent=_unitcomponent.GetById(id);
            DTOUnitComponent dTOUnitComponent = _mapper.Map<DTOUnitComponent>(unitComponent);
            result.IsPass = dTOUnitComponent != null ? true : false;
            result.Data = dTOUnitComponent;
            return result;


        }
        [HttpDelete("DeleteUnitComponent/{id}")]
        public ActionResult<DTOResult> DeleteUnitComponent(int id)
        {
            DTOResult result = new DTOResult();
            UnitComponent unitComponent = _unitcomponent.GetById(id);
            if(unitComponent!= null)
            {
                _unitcomponent.Delete(id);
                _unitcomponent.save();
                result.IsPass = true;
                result.Data = "Deleted";
            }
            else
            {
                result.IsPass = false;
                result.Data = "UnitComponent Not Found";
            }
            return result;
        }
    }
}
