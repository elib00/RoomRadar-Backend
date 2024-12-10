using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;
using RoomRadar_Backend.Repository;
using RoomRadar_Backend.Repository.Interfaces;
using RoomRadar_Backend.Services.Interfaces;

namespace RoomRadar_Backend.Services
{
    public class UserService : IUserService
    {

        public readonly IUserRepository? _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ApiResponseDTO GetAllUsers()
        {
            List<User> users = _userRepository.GetAllUsers();
            return new ApiResponseDTO
            {
                Success = true,
                Type = "Valid",
                Data = users
            };
        }

        public ApiResponseDTO GetUserById(int id)
        {
            User userFromDb = _userRepository.GetUserById(id);

            if(userFromDb == null)
            {
                return new ApiResponseDTO
                {
                    Success = false,
                    Type = "UserNotFound",
                    Data = null
                };
            }

            return new ApiResponseDTO
            {
                Success = true,
                Type = "Valid",
                Data = userFromDb
            };
        }

        public ApiResponseDTO DeletePendingLandLordById(int id)
        {
            PendingLandLord landLordToDelete = _userRepository.GetPendingLandLordById(id);
            if(landLordToDelete == null)
            {
                return new ApiResponseDTO
                {
                    Success = false,
                    Type = "LandLordNotFound",
                    Data = null
                };
            }

            _userRepository.DeletePendingLandLord(landLordToDelete);
            return new ApiResponseDTO
            {
                Success = true,
                Type = "DeletedPendingLandLord",
                Data = null
            };
        }

        public ApiResponseDTO GetAllPendingLandLords()
        {
            List<PendingLandLord> pendingLandLords = _userRepository.GetAllPendingLandLords();
            return new ApiResponseDTO
            {
                Success = true,
                Type = "PendingLandLordsFetchSuccessful",
                Data = pendingLandLords
            };
        }



    }
}
