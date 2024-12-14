using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Services.Interfaces
{
    public interface IBoardingHouseService
    {
        public ApiResponseDTO GetAllBoardingHousesForViewing();
        public ApiResponseDTO CreateBoardingHouseListing(BoardingHouseListingDTO boardingHouseDetails);
        public ApiResponseDTO AddBoardingHouseRating(CreateRatingDTO ratingDTO);
        public ApiResponseDTO AddBoardingHouseFavorite(CreateFavoriteDTO favDTO);
        public ApiResponseDTO GetBoardingHouseDetails(int boardingHouseId);
    }
}
