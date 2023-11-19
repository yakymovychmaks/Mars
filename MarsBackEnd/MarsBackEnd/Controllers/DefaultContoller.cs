using MarsBackEnd.APIServices;
using MarsBackEnd.Models.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            // Логіка для обробки POST-запиту
            return Ok($"Received value: {value}");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            // Логіка для обробки PUT-запиту
            return Ok($"Updated value with ID {id} to: {value}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Логіка для обробки DELETE-запиту
            return Ok($"Deleted value with ID {id}");
        }
    }
}
