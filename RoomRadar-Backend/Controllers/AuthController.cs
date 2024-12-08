using Microsoft.AspNetCore.Mvc;
using RoomRadar_Backend.Models;
using RoomRadar_Backend.Services.Interfaces;

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
        public IActionResult CreateUser(User user)
        {

            return Ok(user);
        }

    }
}
