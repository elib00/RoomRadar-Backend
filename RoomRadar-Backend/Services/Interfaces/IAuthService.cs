using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Services.Interfaces
{
    public interface IAuthService
    {
        User ValidateUser(UserValidationDTO userValidationCredentails);
        User CreateUser(UserRegistrationDTO userRegistrationCredentials);
    }
}
