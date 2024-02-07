using BLL.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MarsBackEnd.Controllers
{
    [Route("api/Apointment")]
    [ApiController]
    public class ApointmentController : ControllerBase
    {
        private readonly ApointmentService _apointmentService;
        public ClaimsPrincipal claimsPrincipal;
        public ApointmentController(ApointmentService apointmentAPIService)
        {
            _apointmentService = apointmentAPIService;
            claimsPrincipal = User as ClaimsPrincipal;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAllApointment()
        {
            
            var response = _apointmentService.GetAllApointments(claimsPrincipal);
            if(response.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode, response.Result.Description);
            }
            var jsonResult = JsonConvert.SerializeObject(response.Result.Data);
            return Ok(jsonResult);

        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetApointmentBuId(int id)
        {
            var response = _apointmentService.GetApointment(id, claimsPrincipal);
            if(response.Result.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode, response.Result.Description);
            }
            var jsonResult = JsonConvert.SerializeObject(response.Result.Data);
            return Ok(jsonResult);
        }
        [HttpPost]
        public IActionResult AddApointment([FromBody] Apointment apointment)
        {
            var response = _apointmentService.Create(apointment,claimsPrincipal);
            if(response.Result.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode, response.Result.Description);
            }
            var jsonResult = JsonConvert.SerializeObject(response.Result.Data);
            return Ok(jsonResult);
        }
        [HttpDelete]
        public IActionResult DeleteApointment([FromBody] Apointment apointment)
        {
            var response = _apointmentService.Create(apointment, claimsPrincipal);
            if(response.Result.StatusCode== Domain.Enum.StatusCode.OK)
            {
                return StatusCode((int)response.Result.StatusCode, response.Result.Description);
            }
            var jsonResult = JsonConvert.SerializeObject(response.Result.Data);
            return Ok(jsonResult);
        }
    }
}
