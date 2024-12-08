using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Repository
{
    public interface IAuthRepository
    {   
        public User ValidateUser(User user);
        public User CreateUser(User user);
    }
}
