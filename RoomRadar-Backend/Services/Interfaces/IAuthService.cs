using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Services.Interfaces
{
    public interface IAuthService
    {
        User ValidateUser(User user);
    }
}
