using MarsBackEnd.APIServices;
using MarsBackEnd.Models.UserAPIModeles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarsBackEnd.Controllers
{
    [Route("api/Apointment")]
    [ApiController]
    public class ApointmentController : ControllerBase
    {
        private ApointmentAPIService _apointmentAPIService;
        public ApointmentController(ApointmentAPIService apointmentAPIService)
        {
            _apointmentAPIService = apointmentAPIService;
        }

        [HttpGet]
        public IActionResult GetAllApointment()
        {
            return Ok(_apointmentAPIService.GetAllApointmentAsJosn());
        }
        [HttpGet("{id}")]
        public IActionResult GetApointmentBuId(int id)
        {
            return Ok(_apointmentAPIService.GetApointmentBuIdAsJson(id));
        }
        [HttpPost]
        public IActionResult AddApointment([FromBody] ApointmentAPIModel apointmentAPIModel)
        {
            return Ok(_apointmentAPIService.AddApointment(apointmentAPIModel);
        }
        [HttpDelete]
        public IActionResult DeleteApointment([FromBody] ApointmentAPIModel apointmentAPIModel)
        {
            return Ok(_apointmentAPIService.DeleteApointment(apointmentAPIModel));
        }
    }
}
