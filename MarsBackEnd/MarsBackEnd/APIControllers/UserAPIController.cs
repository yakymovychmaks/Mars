using BLL.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                var response = _userService.GetUsers();

                var jsonResult = new JsonResult(response);
                jsonResult.StatusCode = 200;

                return jsonResult;
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok(_userService.GetUserByIdJson(id));
        //}
        [HttpPost]
        public IActionResult AddUser([FromBody] User userAPI)
        {
            try
            {
                var response = _userService.Create(userAPI);

                var jsonResult = new JsonResult(response);
                jsonResult.StatusCode = 200;

                return jsonResult;
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
        //[HttpPut]
        //public IActionResult UpdateUser([FromBody] User userAPI)
        //{
        //    return Ok(_userService.UpdataUser(userAPI));
        //}
        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            try
            {
                var response = _userService.DeleteUser(id);

                var jsonResult = new JsonResult(response);
                jsonResult.StatusCode = 200;

                return jsonResult;
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

    }
}
