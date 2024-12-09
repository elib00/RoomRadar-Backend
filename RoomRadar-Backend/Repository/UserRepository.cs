using Microsoft.EntityFrameworkCore;
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

    }
}
