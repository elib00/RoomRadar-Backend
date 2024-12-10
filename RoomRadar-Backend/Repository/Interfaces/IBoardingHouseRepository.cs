using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Repository.Interfaces
{
    public interface IBoardingHouseRepository
    {
        public List<BoardingHouseForViewingDTO> GetAllBoardingHousesForViewing();
        public void CreateBoardingHouseListing(BoardingHouse boardingHouseDetails);
        public void AddBoardingHouseRating(Rating rating);
    }
}
