using Azure;
using BLL.Services;
using Domain.Entity;
using Domain.LoginModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace MarsBackEnd.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserAPIController : Controller
    {
        private UserService _userService { get; set; }
        public UserAPIController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Register([FromBody] RegisterViewModel registerViewModel)
        {
            var rezult = _userService.Register(registerViewModel);
            if (rezult.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)rezult.Result.StatusCode, rezult.Result.Description);
            }
            var jsonRezult = JsonConvert.SerializeObject(rezult.Result.Description);
            return Ok(jsonRezult);
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel loginViewModel)
        {
            var rezult = _userService.Login(loginViewModel);
            if (rezult.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)rezult.Result.StatusCode, rezult.Result.Description);
            }
            var jsonRezult = JsonConvert.SerializeObject(rezult.Result.Description);
            return Ok(jsonRezult);
        }
        
    }
}
