using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User>  userManager;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        public AccountController(UserManager<User> userManager, IConfiguration configuration,IMapper mapper)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.mapper = mapper;
            
        }


        [HttpPost("Register")]
        public async Task< ActionResult<DTOResult>> Register(DTORegisterUser userRegister)
        {
            DTOResult result = new DTOResult();
            if (ModelState.IsValid)
            {
               User UserModel= mapper.Map<User>(userRegister);
               IdentityResult identityresult = await userManager.CreateAsync(UserModel, userRegister.Password);
                if(identityresult.Succeeded)
                {
                    result.IsPass= true;
                    result.Data = "Registered succesfully";
                }
                else
                {
                    result.IsPass= false;
                    result.Data = "Failed Registeration";
                }
            }

            else
            {
                result.IsPass = false;
                result.Data = "Data is not vaild";
            }
            return result;
        }
    }
}
