using Microsoft.AspNetCore.Mvc;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UsersController: ControllerBase
    {
        [HttpGet]
        [Route("", Name = "GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(new User
            {
                Id = 1, 
                Account = new UserAccount
                {
                    Id = 1,
                    Email = "joshuanapinas@gmail.com",
                    Password = "123",
                    UserId = 1
                },
                Profile = new UserProfile
                {
                    Id = 1,
                    IsLandLord = false,
                    FirstName = "Joshua",
                    LastName = "Napinas",
                    ContactNumber = "09292260864",
                    UserId = 1
                }
            });
        }    
    }
}
