using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Services
{
    public interface IUserService
    {
        public UserResponseDTO GetAllUsers();
        public UserResponseDTO GetUserById(int id);

        public UserResponseDTO DeletePendingLandLordById(int id);
        public UserResponseDTO GetAllPendingLandLords();
    }
}
