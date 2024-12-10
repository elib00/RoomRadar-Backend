using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Services.Interfaces
{
    public interface IAuthService
    {
        ApiResponseDTO ValidateUser(UserValidationDTO userValidationCredentials);
        ApiResponseDTO CreateUser(UserRegistrationDTO userRegistrationCredentials);
    }
}
