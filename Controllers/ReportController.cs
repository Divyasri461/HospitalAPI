using HospitalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        // ✅ CONSOLIDATED REPORT
        [HttpGet("appointments")]
        public async Task<IActionResult> GetAppointmentReport()
        {
            var result = await _service.GetAppointmentReport();
            return Ok(result);
        }

        // ✅ REVENUE BY SPECIALIZATION
        [HttpGet("revenue-by-specialization")]
        public async Task<IActionResult> GetRevenueBySpecialization()
        {
            var result = await _service.GetRevenueBySpecialization();
            return Ok(result);
        }

        // ✅ DOCTOR APPOINTMENT COUNT (>2)
        [HttpGet("doctor-appointment-counts")]
        public async Task<IActionResult> GetDoctorAppointmentCounts()
        {
            var result = await _service.GetDoctorAppointmentCounts();
            return Ok(result);
        }

        // ✅ SAME DOCTOR SAME DATE PATIENTS
        [HttpGet("same-doctor-same-date-patients")]
        public async Task<IActionResult> GetSameDoctorSameDatePatients()
        {
            var result = await _service.GetSameDoctorSameDatePatients();
            return Ok(result);
        }

        // ✅ NEXT 7 DAYS
        [HttpGet("next-7-days")]
        public async Task<IActionResult> GetAppointmentsNext7Days()
        {
            var result = await _service.GetAppointmentsNext7Days();
            return Ok(result);
        }
    }
}