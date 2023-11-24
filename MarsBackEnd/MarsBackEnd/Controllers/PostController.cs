using MarsBackEnd.APIServices;
using Microsoft.AspNetCore.Mvc;

namespace MarsBackEnd.Controllers
{
    [Route("api/postcontrol")]
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
    }
}
