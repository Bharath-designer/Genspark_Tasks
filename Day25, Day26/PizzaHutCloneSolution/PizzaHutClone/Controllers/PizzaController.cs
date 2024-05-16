using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHutClone.Exceptions;
using PizzaHutClone.Models.DTOs;
using PizzaHutClone.Services;

namespace PizzaHutClone.Controllers
{
    [ApiController]
    [Route("pizza")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _service;

        public PizzaController(PizzaService _service)
        {
            this._service = _service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pizzas = await _service.GetAllPizzas();
                return Ok(pizzas);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPizzaById(int id)
        {
            try
            {
                var pizza = await _service.GetPizzaById(id);
                return Ok(pizza);

            }
            catch(NoPizzaFoundException npfe)
            {
                return NotFound(npfe.Message);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPizza([FromBody] AddPizzaDTO pizzaDTO )
        {
            await Console.Out.WriteLineAsync(pizzaDTO == null ? pizzaDTO.ToString() : $"{pizzaDTO.Name}, {pizzaDTO.PriceInRupees}");
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var customErrorResponse = new
                    {
                        Status = 400,
                        Title = "One or more validation errors occurred.",
                        Errors = errors
                    };

                    return BadRequest(customErrorResponse);
                }
                await _service.AddPizza(pizzaDTO);
                return Ok("Pizza Created Successfully");
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
