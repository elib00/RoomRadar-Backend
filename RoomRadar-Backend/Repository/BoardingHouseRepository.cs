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
                .Include(b => b.Ratings)
                .Select(b => new BoardingHouseForViewingDTO
                {
                    BoardingHouseId = b.Id,
                    Latitude = b.Location.Latitude,
                    Longitude = b.Location.Longitude,
                    Price = b.MonthlyRate,
                    LandLordFirstName = b.LandLord.Profile.FirstName,
                    LandLordLastName = b.LandLord.Profile.LastName,
                    LandLordContactNumber = b.LandLord.Profile.ContactNumber,
                    TruncatedAverageRating = GetAverageRating(b),
                    TotalFavoritesFromUsers = GetTotalFavoritesFromUsers(b)
                })
                .ToList();

        }

        public void CreateBoardingHouseListing(BoardingHouse boardingHouse)
        {
            _backendDbContext.BoardingHouses.Add(boardingHouse);
            _backendDbContext.SaveChanges();
        }

        public void AddBoardingHouseRating(Rating newRating)
        {
            _backendDbContext.Ratings.Add(newRating);
            _backendDbContext.SaveChanges(true);
        }

        private static int GetAverageRating (BoardingHouse boardingHouse)
        {
            ICollection<Rating> ratings = boardingHouse.Ratings;
            if (ratings.Count == 0) return 0;

            double averageRating = ratings.Average(rating => rating.Star);

            return (int)Math.Floor(averageRating);
        }

        private static int GetTotalFavoritesFromUsers(BoardingHouse boardingHouse)
        {
            return boardingHouse.Favorites.Count;
        }
    }
}
