using MarsBackEnd.APIServices;
using MarsBackEnd.Models.UserAPIModeles;
using Microsoft.AspNetCore.Mvc;

namespace MarsBackEnd.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private PostAPIService _postAPIService;
        public PostController(PostAPIService postAPIService)
        {
            _postAPIService = postAPIService;
        }
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            try
            {
                return Ok(_postAPIService.GetAllPostsByJson());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            try
            {
                return Ok(_postAPIService.GetPostByIdAsJson(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddPost([FromBody] PostsAPIModel postsAPIModel)
        {
            try
            {
                return Ok(_postAPIService.AddPsot(postsAPIModel));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeletePostById(int id) 
        {
            try
            {
                return Ok(_postAPIService.DeletePsot(id));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
