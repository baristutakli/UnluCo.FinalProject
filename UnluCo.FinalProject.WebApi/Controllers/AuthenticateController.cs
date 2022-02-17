using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Common.Tools;
using UnluCo.FinalProject.WebApi.Models;
using Newtonsoft.Json.Converters;
namespace UnluCo.FinalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticateController(IUserService userService, UserManager<User> userManager, IConfiguration configuration)
        {
            _userService = userService;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            // user locked out çalıştı bu kısmı düzenlemen gerek  
            var user = await _userService.FindByEmailAsync(model.Email);
            if (!await _userManager.IsLockedOutAsync(user))
            {
                if (await _userService.CheckUser(user, model))
                {
                    TokenGenerator generator = new TokenGenerator(_userManager, _configuration);
                    var token = await generator.GenerateToken(user);
                    return Ok(token);
                }
            }


            await _userManager.SetLockoutEnabledAsync(user, true);
            await _userManager.AccessFailedAsync(user);

            if (await _userManager.GetAccessFailedCountAsync(user) >= 3)
            {

                await _userManager.IsLockedOutAsync(user);
            }


            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
        {
            var userExists = await _userService.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User already exists!" });

            var result = await _userService.CreateUser(model);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpGet]
        public async Task<IActionResult> Deneme()
        {
            var result = await _userService.Deneme();


            return Ok(SerialiObjcet(result));
            // return Ok();
        }
        private string SerialiObjcet(object value)
        {
            var newObject = JsonConvert.SerializeObject(value, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            }
        );
            return newObject;
        }


        //[Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserModel model)
        {
            var userExists = await _userService.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });


            var result = _userService.CreateAdmin(model);

            if (!result.Result.Result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            await _userService.CreateAdminRole(result.Result.User, Roles.Admin);

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}
