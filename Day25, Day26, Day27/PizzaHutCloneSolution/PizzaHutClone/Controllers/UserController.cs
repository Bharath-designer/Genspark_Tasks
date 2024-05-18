using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHutClone.Exceptions;
using PizzaHutClone.Models.DTO;
using PizzaHutClone.Models.DTOs;
using PizzaHutClone.Services;

namespace PizzaHutClone.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/auth")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService _userService)
        {
            this._userService = _userService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO userRegisterDTO)
        {
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

                await _userService.RegisterUser(userRegisterDTO);

                return Ok("request success");
            }
            catch (UserEmailAlreadyRegisteredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }


        }
        
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
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

                LoginReturnDTO loginReturn = await _userService.Login(loginDTO);

                return Ok(loginReturn);

            }
            catch (UnauthorizedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }
    }
}
