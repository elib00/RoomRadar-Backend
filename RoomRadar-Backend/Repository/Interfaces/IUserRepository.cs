using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.Repository
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public List<PendingLandLord> GetAllPendingLandLords();
        public PendingLandLord GetPendingLandLordById(int id);
        public void DeletePendingLandLord(PendingLandLord pendingLandLord);
        public List<BoardingHouseForViewingDTO> GetLandLordListings(int landLordId);

    }
}