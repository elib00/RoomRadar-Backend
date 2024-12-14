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
                .Include(b => b.Favorites)
                .Select(b => new BoardingHouseForViewingDTO
                {
                    BoardingHouseId = b.Id,
                    Latitude = b.Location.Latitude,
                    Longitude = b.Location.Longitude,
                    Price = b.MonthlyRate,
                    LandLordFirstName = b.LandLord.Profile.FirstName,
                    LandLordLastName = b.LandLord.Profile.LastName,
                    LandLordContactNumber = b.LandLord.Profile.ContactNumber,
                    TruncatedAverageRating = b.Ratings.Any() ? (int)Math.Floor(b.Ratings.Average(rating => rating.Star)) : 0,
                    TotalFavoritesFromUsers = b.Favorites.Count

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

        public bool UserAlreadyRatedBoardingHouse(int userId, int boardingHouseId)
        {
            return _backendDbContext.Ratings.Any(r => r.UserId == userId && r.BoardingHouseId == boardingHouseId);
        }


        public void AddBoardingHouseFavorite(Favorite favorite)
        {
            _backendDbContext.Favorites.Add(favorite);
            _backendDbContext.SaveChanges();
        }

        public bool UserAlreadyFavoritedBoardingHouse(int userId, int boardingHouseId)
        {
            return _backendDbContext.Favorites.Any(f => f.UserId == userId && f.BoardingHouseId == boardingHouseId);
        }

        public BoardingHouse GetBoardingHouseDetails(int boardingHouseId)
        {
            return _backendDbContext.BoardingHouses
                .Include(b => b.Ratings)
                .Include(b => b.LandLord)
                    .ThenInclude(u => u.Profile)
                .FirstOrDefault(b => b.Id == boardingHouseId);
        }

        //private static int GetAverageRating (BoardingHouse boardingHouse)
        //{
        //    ICollection<Rating> ratings = boardingHouse.Ratings;
        //    if (ratings.Count == 0) return 0;

        //    double averageRating = ratings.Average(rating => rating.Star);

        //    return (int)Math.Floor(averageRating);
        //}

        //private static int GetTotalFavoritesFromUsers(BoardingHouse boardingHouse)
        //{
        //    return boardingHouse.Favorites.Count;
        //}
    }
}
