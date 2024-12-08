using RoomRadar_Backend.Models;
using RoomRadar_Backend.Repository.Interfaces;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace RoomRadar_Backend.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BackendDbContext? _backendDbContext;

        public AuthRepository(BackendDbContext? backendDbContext)
        {
            _backendDbContext = backendDbContext;
        }

        public bool IsExistingEmail(string email)
        {
            return _backendDbContext.UserAccounts.Any(ua => ua.Email == email);
        }

        public User GetUserByEmail(string email)
        {
            return _backendDbContext.Users
               .Include(u => u.Account)
               .Include(u => u.Profile)
               .FirstOrDefault(u => u.Account.Email == email);
        }

        public void CreateUser(User newUser)
        {
            _backendDbContext.Users.Add(newUser);
            _backendDbContext.SaveChanges();
        }

    }
}
