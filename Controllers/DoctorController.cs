using HospitalAPI.DTOs.DoctorDto;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using HospitalAPI.Services.Interfaces;
namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        // ✅ CREATE DOCTOR (201)
        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // ✅ 400

            try
            {
                await _service.Create(dto);

                return Created("", new
                {
                    message = "Doctor created successfully"
                }); // ✅ 201
            }
            catch (SqlException ex)
            {
                return Conflict(new   // ✅ 409
                {
                    message = ex.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new   // ✅ 500
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ UPDATE DOCTOR (200 / 404)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // ✅ 400

            try
            {
                var existing = await _service.GetDoctorById(id);

                if (existing == null)
                    return NotFound(new   // ✅ 404
                    {
                        message = "Doctor not found"
                    });

                await _service.Update(id, dto);

                return Ok(new
                {
                    message = "Doctor updated successfully"
                }); // ✅ 200
            }
            catch (SqlException ex)
            {
                return Conflict(new   // ✅ 409
                {
                    message = ex.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ GET ALL DOCTORS (200)
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctors = await _service.GetAllDoctors();
                return Ok(doctors); // ✅ 200
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ GET DOCTOR BY ID (200 / 404)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _service.GetDoctorById(id);

                if (doctor == null)
                    return NotFound(new   // ✅ 404
                    {
                        message = "Doctor not found"
                    });

                return Ok(doctor); // ✅ 200
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ GET AVAILABLE DOCTORS (200)
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableDoctors()
        {
            try
            {
                var doctors = await _service.GetAvailableDoctors();
                return Ok(doctors); // ✅ 200
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ GET BY SPECIALIZATION (200 / 400)
        [HttpGet("specialization/{specialization}")]
        public async Task<IActionResult> GetDoctorsBySpecialization(string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization))
                return BadRequest(new
                {
                    message = "Specialization is required"
                }); // ✅ 400

            try
            {
                var doctors = await _service.GetDoctorsBySpecialization(specialization);
                return Ok(doctors); // ✅ 200
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }
    }
}