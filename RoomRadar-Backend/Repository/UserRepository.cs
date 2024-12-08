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
                .Include (u => u.Account)
                .Include(u => u.Profile)
                .FirstOrDefault(u => u.Id == id);
        }

    }
}
