using RoomRadar_Backend.Services.Interfaces;
using RoomRadar_Backend.Repository.Interfaces;
using RoomRadar_Backend.Models;
using RoomRadar_Backend.DTO;

namespace RoomRadar_Backend.Services
{
    public class AuthService : IAuthService
    {
        public readonly IAuthRepository? _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public User ValidateUser(UserValidationDTO userValidationCredentails)
        {
            User userFromDb = _authRepository.ValidateUser(userValidationCredentails);
            return userFromDb;
        }

        public User CreateUser(UserRegistrationDTO userRegistrationCredentials)
        {
            User newUser = _authRepository.CreateUser(userRegistrationCredentials);
            return newUser;
        }
    }
}
