using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MarsBackEnd.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : Controller
    {
        private PostService _postService { get; set; }
        public PostController(PostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAllPosts()
        {
            // Отримати ClaimsPrincipal, який містить інформацію про поточного користувача
            var claimsPrincipal = User as ClaimsPrincipal;

            // Передати claimsPrincipal в _postService або використовуйте його за потреби
            var result = _postService.GetAll(claimsPrincipal);
            return Ok(JsonConvert.SerializeObject(result));
            
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
