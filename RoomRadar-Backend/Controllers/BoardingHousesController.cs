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

        [HttpPost]
        [Route("add-rating/", Name = "AddBoardingHouseRating")]
        public IActionResult AddBoardingHouseRating([FromBody] CreateRatingDTO ratingDTO)
        {
            ApiResponseDTO response = _boardingHouseService.AddBoardingHouseRating(ratingDTO);
            return Ok(response);
        }

        [HttpPost]
        [Route("add-favorite/", Name = "AddBoardingHouseFavorite")]
        public IActionResult AddBoardingHouseFavorite([FromBody] CreateFavoriteDTO boardingHouseFavoriteDTO)
        {
            ApiResponseDTO response = _boardingHouseService.AddBoardingHouseFavorite(boardingHouseFavoriteDTO);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}/")]
        public IActionResult GetBoardingHouseDetails(int id)
        {
            ApiResponseDTO response = _boardingHouseService.GetBoardingHouseDetails(id);
            return Ok(response);
        }
    } 
}
