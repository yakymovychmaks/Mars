using MarsBackEnd.APIServices;
using MarsBackEnd.Models.UserAPIModeles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarsBackEnd.Controllers
{
    [Route("api/coment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentAPIService _commentAPIService;
        public CommentController(CommentAPIService commentAPIService)
        {
            _commentAPIService = commentAPIService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_commentAPIService.GetAllCommentAsJson());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_commentAPIService.GetCommentByIdAsJson(id));
        }
        [HttpPost]
        public IActionResult AddNewComment([FromBody] CommentAPImodel comment)
        {
            return Ok(_commentAPIService.AddComment(comment));
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] CommentAPImodel comment)
        {
            return Ok(_commentAPIService.DeleteComment(comment));
        }
    }
}
