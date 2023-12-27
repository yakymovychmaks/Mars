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
                return Ok(_postAPIService.GetAllPostsByJson());
        }
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
                return Ok(_postAPIService.GetPostByIdAsJson(id));
        }
        [HttpPost]
        public IActionResult AddPost([FromBody] PostsAPIModel postsAPIModel)
        {
                return Ok(_postAPIService.AddPsot(postsAPIModel));
        }
        [HttpDelete]
        public IActionResult DeletePostById([FromBody] PostsAPIModel postsAPIModel) 
        {
                return Ok(_postAPIService.DeletePsot(postsAPIModel));
        }
    }
}
