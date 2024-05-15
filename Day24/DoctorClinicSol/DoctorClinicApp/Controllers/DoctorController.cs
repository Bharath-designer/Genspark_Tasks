using DoctorClinicApp.Exceptions;
using DoctorClinicApp.Models;
using DoctorClinicApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApp.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService service;
        public DoctorController(DoctorService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                IEnumerable<Doctor> doctors = await service.GetAllDoctors();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the data.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            try
            {
                Doctor doctor = await service.GetDoctorById(id);
                return Ok(doctor);
            }
            catch (DoctorNotFountException dnfe)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Doctor with the given Id not found");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                var customErrorResponse = new
                {
                    Status = 401,
                    Title = "One or more validation errors occurred.",
                    Errors = errors
                };

                return BadRequest(customErrorResponse);
            }

            var doctor = new Doctor
            {
                Name = model.Name,
                PhoneNumber = model.Phone,
                Specialization = model.Specialization
            };

            await service.AddDoctor(doctor);

            return Ok("Doctor created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctorSpecialization(int id, [FromBody] string specialization)
        {
            if (string.IsNullOrEmpty(specialization))
            {
                return BadRequest("Specialization is required.");
            }
            
            try
            {
            await service.UpdateDoctorSpecialization(id, specialization);
            return Ok("Doctor specialization have been updated");    

            } catch (DoctorNotFountException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }

        }

    }
}
