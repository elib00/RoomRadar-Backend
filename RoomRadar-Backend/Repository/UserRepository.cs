using Microsoft.EntityFrameworkCore;
using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BackendDbContext? _backendDbContext;

        public UserRepository(BackendDbContext? backendDbContext)
        {
            _backendDbContext = backendDbContext;
        }

        public List<User> GetAllUsers()
        {
            return _backendDbContext.Users
                .Include(u => u.Account)
                .Include(u => u.Profile)
                .ToList();
        }

        public User GetUserById(int id)
        {
            return _backendDbContext.Users
                .Include(u => u.Account)
                .Include(u => u.Profile)
                .FirstOrDefault(u => u.Id == id);
        }

        public PendingLandLord GetPendingLandLordById(int id)
        {
            return _backendDbContext.PendingLandLords.FirstOrDefault(pl => pl.Id == id);
        }

        public List<PendingLandLord> GetAllPendingLandLords()
        {
            return _backendDbContext.PendingLandLords
                .Include(pl => pl.LandLord)
                    .ThenInclude(user => user.Account)
                .Include(pl => pl.LandLord)
                    .ThenInclude(user => user.Profile)
                .ToList();
        }

        public void DeletePendingLandLord(PendingLandLord pendingLandLord)
        {
            _backendDbContext.PendingLandLords.Remove(pendingLandLord);
            _backendDbContext.SaveChanges();
        }

        public List<BoardingHouseForViewingDTO> GetLandLordListings(int landLordId)
        {
            return _backendDbContext.BoardingHouses
                .Where(b => b.LandLordId == landLordId)
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

    }
}
