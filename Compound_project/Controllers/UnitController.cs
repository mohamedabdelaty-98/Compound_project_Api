using BussienesLayer.Reposatories;
using Compound_project.DTO;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnit _unit;

        public UnitController(IUnit _unit)
        {
            this._unit = _unit;
        }
        [HttpGet("UnitsActive")]
        public ActionResult<DTOResult> UnitsActive()
        {
            List<Unit> units = _unit.FilterByStatus();
            DTOResult result = new DTOResult();
            if (units == null || units.Count == 0) result.IsPass = false;
            else result.IsPass=true;
            result.Data = units;
            return result;
        }
    }
}
