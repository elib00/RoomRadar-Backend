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

        public AuthResponseDTO ValidateUser(UserValidationDTO userValidationCredentials)
        {
            string? email = userValidationCredentials.Email;
            string? password = userValidationCredentials.Password;

            User? userFromDB = _authRepository.GetUserByEmail(email);

            if (userFromDB != null)
            {
                if (ValidatePassword(password, userFromDB.Account.Password))
                {
                    return new AuthResponseDTO
                    {
                        IsSuccess = true,
                        Type = "Valid",
                        User = userFromDB
                    };
                }
                else
                {
                    return new AuthResponseDTO
                    {
                        IsSuccess = false,
                        Type = "IncorrectPassword",
                        User = null
                    };
                }
            }
            else
            {
                return new AuthResponseDTO
                {
                    IsSuccess = false,
                    Type = "UserNotFound",
                    User = null
                };
            }
        }

        public AuthResponseDTO CreateUser(UserRegistrationDTO userRegistrationCredentials)
        {
            string? newUserEmail = userRegistrationCredentials.Email;

            bool isExistingEmail = _authRepository.IsExistingEmail(newUserEmail);

            if (isExistingEmail)
            {
                return new AuthResponseDTO
                {
                    IsSuccess = false,
                    Type = "EmailAlreadyInUse",
                    User = null
                };
            }

            UserProfile profile = new UserProfile
            {
                IsLandLord = userRegistrationCredentials.IsLandLord,
                FirstName = userRegistrationCredentials.FirstName,
                LastName = userRegistrationCredentials.LastName,
                ContactNumber = userRegistrationCredentials.ContactNumber,
                Gender = userRegistrationCredentials.Gender,
                BirthDate = userRegistrationCredentials.BirthDate
            };

            UserAccount account = new UserAccount
            {
                Email = userRegistrationCredentials.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userRegistrationCredentials.Password)
            };

            User newUser = new User
            {
                Account = account,
                Profile = profile
            };

            _authRepository.CreateUser(newUser);

            return new AuthResponseDTO
            {
                IsSuccess = true,
                Type = "Valid",
                User = newUser
            };
        }

        private bool ValidatePassword(string password, string pwFromDb)
        {
            return BCrypt.Net.BCrypt.Verify(password, pwFromDb);
        }
    }
}
