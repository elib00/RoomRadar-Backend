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

        public UserResponseDTO GetAllUsers()
        {
            List<User> users = _userRepository.GetAllUsers();
            return new UserResponseDTO
            {
                IsSuccess = true,
                Type = "Valid",
                Data = users
            };
        }

        public UserResponseDTO GetUserById(int id)
        {
            User userFromDb = _userRepository.GetUserById(id);

            if(userFromDb == null)
            {
                return new UserResponseDTO
                {
                    IsSuccess = false,
                    Type = "UserNotFound",
                    Data = null
                };
            }

            return new UserResponseDTO
            {
                IsSuccess = true,
                Type = "Valid",
                Data = userFromDb
            };
        }

        public UserResponseDTO DeletePendingLandLordById(int id)
        {
            PendingLandLord landLordToDelete = _userRepository.GetPendingLandLordById(id);
            if(landLordToDelete == null)
            {
                return new UserResponseDTO
                {
                    IsSuccess = false,
                    Type = "LandLordNotFound",
                    Data = null
                };
            }

            _userRepository.DeletePendingLandLord(landLordToDelete);
            return new UserResponseDTO
            {
                IsSuccess = true,
                Type = "DeletedPendingLandLord",
                Data = null
            };
        }

        public UserResponseDTO GetAllPendingLandLords()
        {
            List<PendingLandLord> pendingLandLords = _userRepository.GetAllPendingLandLords();
            return new UserResponseDTO
            {
                IsSuccess = true,
                Type = "PendingLandLordsFetchSuccessful",
                Data = pendingLandLords
            };
        }



    }
}
