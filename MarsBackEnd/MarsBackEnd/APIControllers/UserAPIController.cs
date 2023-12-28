using BLL.Services;
using Domain.Entity;
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
        [HttpGet]
        public IActionResult GetAll()
        {

            var response = _userService.GetUsers();

            if (response.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode, response.Result.Description);
            }

            var jsonResult = new JsonResult(response.Result.Data);

            return Ok(jsonResult);

        }
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok(_userService.GetUserByIdJson(id));
        //}
        [HttpPost]
        public IActionResult AddUser([FromBody] User userAPI)
        {

            var response = _userService.Create(userAPI);

            if (response.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode, response.Result.Description);
            }


            var jsonResult = new JsonResult(response.Result.Data);

            return Ok(jsonResult);

        }

        //      {
        //"Password": "YourPasswordHere",
        //"Name": "John Doe",
        //"Role": 1,
        //"ProfileId": 1,
        //"Profile": {
        //  "Age": 25,
        //  "Address": "123 Main St",
        //  "UserId": 1
        //},
        //"Posts": [


        //]
        //  }



        //[HttpPut]
        //public IActionResult UpdateUser([FromBody] User userAPI)
        //{
        //    return Ok(_userService.UpdataUser(userAPI));
        //}
        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {

            var response = _userService.DeleteUser(id);

            if (response.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode, response.Result.Description);
            }
            var jsonResult = new JsonResult(response.Result.Data);

            return Ok(jsonResult);
        }

    }

}
