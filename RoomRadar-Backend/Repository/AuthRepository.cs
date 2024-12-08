using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;
using RoomRadar_Backend.Repository.Interfaces;
using BCrypt.Net;

namespace RoomRadar_Backend.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BackendDbContext? _backendDbContext;
           
        public AuthRepository(BackendDbContext? backendDbContext)
        {
            _backendDbContext = backendDbContext;
        }

        public User ValidateUser(UserValidationDTO userValidationCredentials)
        {
            string email = userValidationCredentials.Email;
            string password = userValidationCredentials.Password;
            
            User userFromDB = UserExists(email);

            if(userFromDB != null)
            {
                if(ValidatePassword(password, userFromDB.Account.Password))
                {
                    return userFromDB;
                }
            }

            return userFromDB;
        }

        public User CreateUser(UserRegistrationDTO userRegistrationCredentials)
        {
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

            _backendDbContext.Users.Add(newUser);
            _backendDbContext.SaveChanges();

            return newUser;
        }
        private User UserExists(string email)
        {
            User user = _backendDbContext.Users.FirstOrDefault(u => u.Account.Email == email);
            return user;
        }

        private bool ValidatePassword(string password, string pwFromDb)
        {
            return BCrypt.Net.BCrypt.Verify(password, pwFromDb);
        }

    }
}
