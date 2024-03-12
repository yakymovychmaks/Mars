using BLL.Services;
using Domain.Entity;
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
            var result = _postService.GetAll();
            return Ok(JsonConvert.SerializeObject(result));
            
        }
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var response = _postService.GetPost(id);
            if (response.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode, response.Result.Description);
            }
            var jsonResult = JsonConvert.SerializeObject(response.Result.Data);
            return Ok(jsonResult);
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddPost([FromBody] Post postModel)
        {
            // Отримати ClaimsPrincipal, який містить інформацію про поточного користувача
            var claimsPrincipal = User as ClaimsPrincipal;

            // Передати claimsPrincipal в _postService або використовуйте його за потреби
            var response = _postService.Create(postModel,claimsPrincipal);
            if(response.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode, response.Result.Description);
            }
            var jsonResult = JsonConvert.SerializeObject(response.Result.Data);
            return Ok(jsonResult);
        }
        [HttpDelete]
        [Authorize]
        public IActionResult DeletePostById([FromBody] Post postModel)
        {
            // Отримати ClaimsPrincipal, який містить інформацію про поточного користувача
            var claimsPrincipal = User as ClaimsPrincipal;

            // Передати claimsPrincipal в _postService або використовуйте його за потреби
            var response = _postService.Delete(postModel.Id, claimsPrincipal);
            if(response.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode,response.Result.Description);
            }
            var jsonResult = JsonConvert.SerializeObject(response.Result.Data);
            return Ok(jsonResult);
        }
    }
}
