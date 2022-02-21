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
        private readonly IAuthenticateService _userService;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AuthenticateController(IAuthenticateService userService, UserManager<User> userManager, IConfiguration configuration, IEmailService emailService)
        {
            _userService = userService;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
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
                MailRequest mail2 = new MailRequest() { Body = "Blocked", Status = false, Subject = "Access denied", ToEmail = user.Email };
                _emailService.SendEmailIntoQueue(mail2);
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
