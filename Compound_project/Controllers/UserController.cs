using AutoMapper;
using BussienesLayer.DTO;
using Compound_project.Migrations;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using DataAccessLayer.Reposatories.UserReposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _User;
        private readonly IMapper _mapper;

        public UserController(IUser _User, IMapper _mapper)
        {
            this._User = _User;
            this._mapper = _mapper;
        }

        [HttpGet("GetAllUsers")]
        public ActionResult<DTOResult> GetAllUsers()
        {
            List<User> Users = _User.GetAll();
            List<DTOUser> dTOUsers = Users.Select(item => _mapper.Map<DTOUser>(item)).ToList();
            //foreach (var dTOUser in dTOUsers)
            //{
            //    dTOUser.reveies = _building.FilterByCompoundNumber(dtoCompound.Id)
            //       .Select(c => _mapper.Map<DTOBuilding>(c)).ToList();
            //}



            DTOResult result = new DTOResult();
            result.IsPass = dTOUsers.Count != 0 ? true : false;
            result.Data = dTOUsers;
            return result;
        }
        [HttpGet("UserById/{id}")]
        public ActionResult<DTOResult> UserById(String id)
        {
            User user = _User.GetById(id);
            DTOResult result = new DTOResult();

            if (user != null)
            {
                DTOUser dTOuser = _mapper.Map<DTOUser>(user);
                //dTOBuilding.Units = _unit.FilterByBuildingNumber(id).Select(u => _mapper.Map<DTOUnit>(u)).ToList();
                result.Data = dTOuser;
                result.IsPass = true;

            }
            else
            {
                result.IsPass = false;
                result.Data = "Not Found";
            }
            return result;
        }
    }
}
