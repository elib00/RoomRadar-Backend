using Microsoft.AspNetCore.Mvc;
using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Services.Interfaces;

namespace RoomRadar_Backend.Controllers
{

    [ApiController]
    [Route("api/boarding-houses/")]
    public class BoardingHousesController : ControllerBase // extend this class to be able to return responses lik Ok()
    {
        private readonly IBoardingHouseService _boardingHouseService;

        public BoardingHousesController(IBoardingHouseService boardingHouseService)
        {
            _boardingHouseService = boardingHouseService;
        }

        [HttpGet]
        [Route("view/", Name = "GetAllBoardingHousesForViewing")]
        public IActionResult GetAllBoardingHousesForViewing()
        {
            ApiResponseDTO response = _boardingHouseService.GetAllBoardingHousesForViewing();
            return Ok(response);
        }

        [HttpPost]
        [Route("create-listing/", Name = "CreateBoardingHouseListing")]
        public IActionResult CreateBoardingHouseListing([FromBody] BoardingHouseListingDTO boardingHouseListingDTO)
        {
            ApiResponseDTO response = _boardingHouseService.CreateBoardingHouseListing(boardingHouseListingDTO);
            return Ok(response);
        }
    } 
}
