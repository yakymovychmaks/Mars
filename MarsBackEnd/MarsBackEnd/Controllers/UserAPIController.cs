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
            return Ok(_userAPIService.GetAllUsersAsJson());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userAPIService.GetUserByIdJson(id));
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserAPIModel userAPI) 
        {
            return Ok(_userAPIService.AddUser(userAPI));
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserAPIModel userAPI)
        {
            return Ok(_userAPIService.UpdataUser(userAPI));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int  id)
        {
            return Ok(_userAPIService.DeleteUser(id));
        }
        
    }
}
