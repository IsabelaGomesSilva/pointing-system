using Microsoft.AspNetCore.Mvc;
using Time.Domain;
using Time.Domain.request;
using Time.Service.Interfaces;

namespace Time.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            var appointments = _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        [HttpPost]
        public IActionResult CreateAppointment([FromBody] AppointmentRequest appointment)
        {
            var appointmentId = _appointmentService.CreateAppointment(appointment);
            if (appointmentId == null)
               return BadRequest();
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointmentId }, appointment);
        }
    }
}
