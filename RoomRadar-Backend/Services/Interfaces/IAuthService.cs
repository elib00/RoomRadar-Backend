using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Services.Interfaces
{
    public interface IAuthService
    {
        AuthResponseDTO ValidateUser(UserValidationDTO userValidationCredentails);
        AuthResponseDTO CreateUser(UserRegistrationDTO userRegistrationCredentials);
    }
}
