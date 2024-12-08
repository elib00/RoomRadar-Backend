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
        public IActionResult CreateUser([FromBody] UserRegistrationDTO userRegistrationCredentials)
        {
            AuthResponseDTO response = _authService.CreateUser(userRegistrationCredentials);

            if (!response.IsSuccess && response.Type == "EmailAlreadyInUse")
            {
                return Conflict(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult ValidateUser([FromBody] UserValidationDTO userValidationCredentials)
        {
            AuthResponseDTO response = _authService.ValidateUser(userValidationCredentials);
            if (!response.IsSuccess)
            {
                if(response.Type == "IncorrectPassword")
                {
                    return Unauthorized(response);
                }else if(response.Type == "UserNotFound")
                {
                    return NotFound(response);
                }
            }
            
            return Ok(response);
        }
    }
}
