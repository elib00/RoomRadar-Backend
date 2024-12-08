using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Repository.Interfaces;

public interface IAuthRepository
{
    public bool IsExistingEmail(string email);
    public User GetUserByEmail(string email);
    public void CreateUser(User newUser);
    public void SaveAsPending(PendingLandLord pendingUser);
    public bool HasSubmittedLandLordRequestAlready(User user);
}
