namespace RoomRadar_Backend.DTO
{
    public class CreateFavoriteDTO
    {
        public int UserId { get; set; }
        public int BoardingHouseId { get; set; }
        public int Star { get; set; }
    }
}