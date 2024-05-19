using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHutClone.Exceptions;
using PizzaHutClone.Services;

namespace PizzaHutClone.Controllers
{
    [Route("api/seller/pizza")]
    [ApiController]
    [Authorize(Roles = "SELLER")]
    public class SellerController : ControllerBase
    {

        private readonly PizzaService _service;

        public SellerController(PizzaService _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pizzas = await _service.GetAllPizzaForSeller();
                return Ok(pizzas);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

    }
}
