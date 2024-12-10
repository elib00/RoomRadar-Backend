using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Services
{
    public interface IUserService
    {
        public ApiResponseDTO GetAllUsers();
        public ApiResponseDTO GetUserById(int id);

        public ApiResponseDTO DeletePendingLandLordById(int id);
        public ApiResponseDTO GetAllPendingLandLords();
    }
}
