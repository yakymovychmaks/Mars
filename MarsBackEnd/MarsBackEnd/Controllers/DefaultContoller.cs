using MarsBackEnd.APIServices;
using MarsBackEnd.Models.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarsBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultContoller : ControllerBase
    {
        private AdminAPIService adminAPIService;
        public DefaultContoller(AdminAPIService adminAPIService)
        {
            this.adminAPIService = adminAPIService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(adminAPIService.GetAllAdminAsJson());
        }
        [HttpGet("post")]
        public IActionResult GetAllPosts()
        {
            try
            {
                return Ok(adminAPIService.GetAllPosts());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var adminById = adminAPIService.GetAdminByIdJson(id);
                if (adminById == null)
                {
                    return BadRequest("Invalid user data");
                }
                
                return Ok(adminById);
            }catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AdminAPIModel adminAPIModel)
        {
            try
            {
                if(adminAPIModel == null)
                {
                    return BadRequest("Invalid user data");
                }
                var newAdmin = adminAPIService.AddAdmin(adminAPIModel);
                
                return Ok( $"{adminAPIModel}");
            }catch(Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
            
        }
        [HttpPost("posts")]
        public IActionResult NewPost([FromBody] PostsAPIModel postsAPIModel)
        {
            try
            {
                if (postsAPIModel == null)
                    return BadRequest("Sorry can't be null");
                return Ok(adminAPIService.AddPost(postsAPIModel));
            }catch (Exception ex)
            {
                return BadRequest("sorry: "+ ex.Message);
            }
        }
        

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdminAPIModel value)
        {
            try
            {
                if (value == null)
                    return BadRequest("Something wrong with value for update");
                
                return Ok("Success" + adminAPIService.UpdataAdmin(id, value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message );
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Логіка для обробки DELETE-запиту
            return Ok($"Deleted value with ID {id}");
        }
    }
}
