using Microsoft.AspNetCore.Mvc;
using RoomRadar_Backend.Models;
using RoomRadar_Backend.Services.Interfaces;
using RoomRadar_Backend.DTO;

namespace RoomRadar_Backend.Controllers
{
    [ApiController]
    [Route("api/auth/")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult CreateUser([FromBody] UserRegistrationDTO userRegistration)
        {

            return Ok(userRegistration);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult ValidateUser([FromBody] UserValidationDTO userValidation)
        {
            return Ok(userValidation);
        }

    }
}
