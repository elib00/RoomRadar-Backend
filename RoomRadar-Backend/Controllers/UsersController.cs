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

        [HttpPost]
        [Route("pending-landlord/delete/{id}/", Name = "DeletePendingLandLord")]
        public IActionResult DeletePendingLandLordById(int id)
        {
            UserResponseDTO response = _userService.DeletePendingLandLordById(id);
            if (response.IsSuccess)
            {
                return NoContent();
            }

            return NotFound(response);

        }

        [HttpGet]
        [Route("pending-landlord/", Name = "GetAllPendingLandLords")]
        public IActionResult GetAllPendingLandLords()
        {
            UserResponseDTO response = _userService.GetAllPendingLandLords();
            return Ok(response);
        }
    }
}
