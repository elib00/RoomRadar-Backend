using Microsoft.EntityFrameworkCore;
using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Repository.Interfaces
{
    public interface IBoardingHouseRepository
    {
        public List<BoardingHouseForViewingDTO> GetAllBoardingHousesForViewing();
        public void CreateBoardingHouseListing(BoardingHouse boardingHouseDetails);
        public void AddBoardingHouseRating(Rating rating);
        public bool UserAlreadyRatedBoardingHouse(int userId, int boardingHouseId);
        public void AddBoardingHouseFavorite(Favorite favorite);
        public bool UserAlreadyFavoritedBoardingHouse(int userId, int boardingHouseId);
        public BoardingHouse GetBoardingHouseDetails(int boardingHouseId);
        public List<BoardingHouseForViewingDTO> FilterListings(ListingFiltersDTO listingFilters);
    }
}
