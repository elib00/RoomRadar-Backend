using RoomRadar_Backend.Repository.Interfaces;
using RoomRadar_Backend.Models;
using Microsoft.EntityFrameworkCore;
using RoomRadar_Backend.DTO;

namespace RoomRadar_Backend.Repository
{
    public class BoardingHouseRepository : IBoardingHouseRepository
    {
        private readonly BackendDbContext? _backendDbContext;

        public BoardingHouseRepository(BackendDbContext? backendDbContext)
        {
            _backendDbContext = backendDbContext;
        }

        public List<BoardingHouseForViewingDTO> GetAllBoardingHousesForViewing()
        {
            return _backendDbContext.BoardingHouses
                .Select(b => new BoardingHouseForViewingDTO
                {
                    BoardingHouseId = b.Id,
                    Latitude = b.Location.Latitude,
                    Longitude = b.Location.Longitude,
                    Price = b.MonthlyRate,
                    LandLordFirstName = b.LandLord.Profile.FirstName,
                    LandLordLastName = b.LandLord.Profile.LastName,
                    LandLordContactNumber = b.LandLord.Profile.ContactNumber
                })
                .ToList();

        }

        public void CreateBoardingHouseListing(BoardingHouse boardingHouse)
        {
            _backendDbContext.BoardingHouses.Add(boardingHouse);
            _backendDbContext.SaveChanges();
        }
    }
}
