using RoomRadar_Backend.Services.Interfaces;
using RoomRadar_Backend.Repository.Interfaces;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Services
{
    public class AuthService : IAuthService
    {
        public readonly IAuthRepository? _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public User ValidateUser(User user)
        {
            return user;
        }

        public User CreateUser(User user)
        {
            return user;
        }
    }
}
