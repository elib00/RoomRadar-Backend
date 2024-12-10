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

        public ApiResponseDTO ValidateUser(UserValidationDTO userValidationCredentials)
        {
            string? email = userValidationCredentials.Email;
            string? password = userValidationCredentials.Password;

            User? userFromDB = _authRepository.GetUserByEmail(email);

            if (userFromDB != null)
            {
                if (ValidatePassword(password, userFromDB.Account.Password))
                {
                    return new ApiResponseDTO
                    {
                        Success = true,
                        Type = "Valid",
                        Data = userFromDB
                    };
                }
                else
                {
                    return new ApiResponseDTO
                    {
                        Success = false,
                        Type = "IncorrectPassword",
                        Data = null
                    };
                }
            }
            else
            {
                return new ApiResponseDTO
                {
                    Success = false,
                    Type = "UserNotFound",
                    Data = null
                };
            }
        }

        public ApiResponseDTO CreateUser(UserRegistrationDTO userRegistrationCredentials)
        {
            string? newUserEmail = userRegistrationCredentials.Email;
            bool saveAsPending = userRegistrationCredentials.IsLandLord == true;

            bool isExistingEmail = _authRepository.IsExistingEmail(newUserEmail);

            if (isExistingEmail)
            {
                return new ApiResponseDTO
                {
                    Success = false,
                    Type = "EmailAlreadyInUse",
                    Data = null
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

          

            if (saveAsPending)
            {
                newUser.Profile.IsLandLord = false;
                _authRepository.CreateUser(newUser);
                _authRepository.SaveAsPending(new PendingLandLord { LandLord = newUser });
                return new ApiResponseDTO
                {
                    Success = true,
                    Type = "SavedAsPendingLandLord",
                    Data = newUser
                };
            }
            else
            {
                _authRepository.CreateUser(newUser);
                return new ApiResponseDTO
                {
                    Success = true,
                    Type = "SavedAsUser",
                    Data = newUser
                };
            }
        }

        private bool ValidatePassword(string password, string pwFromDb)
        {
            return BCrypt.Net.BCrypt.Verify(password, pwFromDb);
        }
    }
}
