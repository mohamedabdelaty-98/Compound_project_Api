﻿using AutoMapper;
using BussienesLayer.DTO;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        public async Task<ActionResult<DTOResult>> Register(DTORegisterUser userRegister)
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


        [HttpPost("Login")]
        public async Task<ActionResult<DTOResult>> Login(DTOLoginUser userLogin)
        {
            DTOResult result = new DTOResult();

            if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(userLogin.email);
                if (user != null && await userManager.CheckPasswordAsync(user, userLogin.password)) {

                   
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    var roles = await userManager.GetRolesAsync(user);

                    foreach( var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Securitykey"]));
                    SigningCredentials signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken Token = new JwtSecurityToken(
                        issuer: configuration["JWT:ValidIssuer"],
                        audience: configuration["JWT:ValidAudience"],
                        claims:claims,
                        expires:DateTime.Now.AddHours(1),
                        signingCredentials:signInCredentials
                        );

                    result.IsPass = true;
                    result.Data = new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(Token),
                        expiration = Token.ValidTo
                    };
                
                }
                else
                {
                    result.IsPass = false;
                    result.Data = "Unauthorized";
                }

            }
            return result;
        }
        [HttpPost("AddUsertoRole")]
        public async Task<ActionResult<DTOResult>> AddUsertoRole(string username)
        {
            DTOResult result = new DTOResult();
            var user =await userManager.FindByNameAsync(username);
            if (user == null)
            {
                result.IsPass = false;
                result.Data = "User Not Found";
                return result;
            }
            var addtorole = await userManager.AddToRoleAsync(user, "Admin");
            if(addtorole.Succeeded) {
                result.IsPass = true;
                result.Data = "User added to admin role successfully";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Failed to add user to admin role";
            }
            return result;

        }

        [HttpGet("GetUserRole/{username}")]
        public async Task<ActionResult<DTOResult>> GetUserRole(string username)
        {
            DTOResult result=new DTOResult();
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                result.IsPass=false;
                result.Data = "User Not Found";
                return result;
            }

            var roles = await userManager.GetRolesAsync(user);
            if (roles.Any())
            {
                result.IsPass = true;
                result.Data = roles.First();
                return result;
            }

            return result;
        }
        [HttpPost("Logout")]
        public ActionResult<DTOResult> Logout()
        {
            HttpContext.SignOutAsync();
            DTOResult result = new DTOResult();
            result.IsPass = true;
            result.Data = "Signed out successfully";
            return result;
        }
    }
}
