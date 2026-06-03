using HospitalAPI.DTOs.AppointmentDto;
using HospitalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        // ✅ BOOK APPOINTMENT
        [HttpPost]
        public async Task<IActionResult> BookAppointment(CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.BookAppointment(dto);
                return Created("", new
                {
                    message = "Appointment booked successfully",
                    data = result
                });
            }
            catch (SqlException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // ✅ CANCEL
        [HttpPut("cancel")]
        public async Task<IActionResult> CancelAppointment(CancelAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.CancelAppointment(dto.AppointmentId);

                if (result == null)
                    return NotFound(new { message = "Appointment not found" });

                return Ok(new { message = "Appointment cancelled successfully" });
            }
            catch (SqlException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // ✅ GET ALL
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var result = await _service.GetAllAppointments();
            return Ok(result);
        }

        // ✅ GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var result = await _service.GetAppointmentById(id);

            if (result == null)
                return NotFound(new { message = "Appointment not found" });

            return Ok(result);
        }

        // ✅ UPCOMING
        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcomingAppointments()
        {
            var result = await _service.GetUpcomingAppointments();
            return Ok(result);
        }

        // ✅ BY DOCTOR
        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctor(int doctorId)
        {
            var result = await _service.GetAppointmentsByDoctor(doctorId);
            return Ok(result);
        }

        // ✅ BY PATIENT
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatient(int patientId)
        {
            var result = await _service.GetAppointmentsByPatient(patientId);
            return Ok(result);
        }

        // ✅ UPDATE
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result =await _service.UpdateAppointment(dto);

                if (result == null)
                    return NotFound(new { message = "Appointment not found" });

                return Ok(new { message = "Appointment updated successfully" });
            }
            catch (SqlException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // ✅ COMPLETE
        [HttpPut("complete")]
        public async Task<IActionResult> CompleteAppointment(CompleteAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.CompleteAppointment(dto);

                return Ok(new
                {
                    message = "Appointment completed successfully"
                });
            }
            catch (SqlException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
    }
}