using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHutClone.Exceptions;
using PizzaHutClone.Services;

namespace PizzaHutClone.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController: ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService) { 
            _adminService = adminService;
        }


        [HttpGet("customer/activate/{id}")]
        public async Task<IActionResult> ActivateCustomer(int id)
        {
            try
            {
                await _adminService.ActivateCustomer(id);
                return Ok($"Customer with the Id '{id}' have been Activated!");
            } 
            catch(NoCustomerFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CustomerAlreadyActivatedException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
