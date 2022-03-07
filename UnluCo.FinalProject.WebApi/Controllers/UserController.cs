using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.UsersViewModel;

namespace UnluCo.FinalProject.WebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAll().Result;
            return Ok(JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteUserViewModel deleteUser = new DeleteUserViewModel() { Id = id };
            _userService.Delete(deleteUser);
            return Ok();
        }
    }
}
