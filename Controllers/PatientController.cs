using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using HospitalAPI.Services.Interfaces;
namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        // ✅ CREATE PATIENT (201)
        [HttpPost]
        public async Task<IActionResult> Add(CreatePatientDto dto)
        {
            // ✅ Validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400

            try
            {
                await _service.Add(dto);

                return Created("", new
                {
                    message = "Patient created successfully"
                }); // 201
            }
            catch (SqlException ex)
            {
                // ✅ Duplicate (phone/email)
                return Conflict(new
                {
                    message = ex.Message
                }); // 409
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ UPDATE PATIENT (200 / 404)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400

            try
            {
                var existing = await _service.GetById(id);

                if (existing == null)
                    return NotFound(new
                    {
                        message = "Patient not found"
                    }); // 404

                await _service.Update(id, dto);

                return Ok(new
                {
                    message = "Patient updated successfully"
                }); // 200
            }
            catch (SqlException ex)
            {
                return Conflict(new
                {
                    message = ex.Message
                }); // 409
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ GET ALL ACTIVE PATIENTS (200)
        [HttpGet("active")]
        public async Task<IActionResult> GetAllActivePatients()
        {
            try
            {
                var patients = await _service.GetAllActivePatients();

                return Ok(patients); // 200
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ DELETE (DEACTIVATE) (204 / 404)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var existing = await _service.GetById(id);

                if (existing == null)
                    return NotFound();

                await _service.Delete(id);

                return NoContent(); // ✅ correct
            }


            catch (ApplicationException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                }); // 400
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ GET BY ID (200 / 404)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var patient = await _service.GetById(id);

                if (patient == null)
                    return NotFound(new
                    {
                        message = "Patient not found"
                    }); // 404

                return Ok(patient); // 200
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error"
                });
            }
        }

        // ✅ SEARCH PATIENTS (200 / 400)
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return BadRequest(new
                {
                    message = "Search term is required"
                }); // 400

            try
            {
                var result = await _service.SearchPatients(term);

                return Ok(result); // 200
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