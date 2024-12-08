using RoomRadar_Backend.Models;
using RoomRadar_Backend.Repository.Interfaces;

namespace RoomRadar_Backend.Repository
{
    public class AuthRepository : IAuthRepository
    {
        public User ValidateUser(User user)
        {
            return user;
        }

        public User CreateUser(User user)
        {
            return user;
        }
    }
}
