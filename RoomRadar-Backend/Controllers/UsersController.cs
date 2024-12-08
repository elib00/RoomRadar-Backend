using Microsoft.AspNetCore.Mvc;
using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Services;
using RoomRadar_Backend.Services.Interfaces;

namespace RoomRadar_Backend.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("", Name = "GetUsers")]
        public IActionResult GetUsers()
        {
            UserResponseDTO response = _userService.GetAllUsers();
            return Ok(response); 
        }    

        [HttpGet]
        [Route("{id}/", Name = "GetUserById")]
        public IActionResult GetUserById(int id)
        {
            UserResponseDTO response = _userService.GetUserById(id);
            if (!response.IsSuccess && response.Type == "UserNotFound")
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
