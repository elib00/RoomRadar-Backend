using Microsoft.AspNetCore.Mvc;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Controllers
{
    [ApiController]
    public class UsersController: ControllerBase
    {
        [HttpGet]
        [Route("api/users")]
        public JsonResult GetUsers()
        {
            return new JsonResult(new User
            {
                Id = 1,
                FirstName = "Joshua",
                LastName = "Napinas",
                Email = "joshuanapinas@gmail.com",
                ContactNumber = "09292260864",
                IsLandLord = true
            });

        }    
    }
}
