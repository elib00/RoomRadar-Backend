using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Repository.Interfaces;

public interface IAuthRepository
{   
    public User ValidateUser(UserValidationDTO userValidationCredentials);
    public User CreateUser(UserRegistrationDTO userRegistrationCredentials);
}
