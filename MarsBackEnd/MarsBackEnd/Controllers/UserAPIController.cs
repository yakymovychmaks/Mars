using MarsBackEnd.APIServices;
using MarsBackEnd.Models.UserAPIModeles;
using Microsoft.AspNetCore.Mvc;

namespace MarsBackEnd.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserAPIController : Controller
    {
        private UserAPIService _userAPIService { get; set; }
        public UserAPIController(UserAPIService userAPIService)
        {
            _userAPIService = userAPIService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userAPIService.GetAllAdminAsJson());
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserAPIModel userAPI) 
        {
            if (userAPI == null) { return BadRequest("Can't be null"); }
            _userAPIService.AddUser(userAPI);
            return Ok(_userAPIService.GetAllAdminAsJson());
        }
    }
}
