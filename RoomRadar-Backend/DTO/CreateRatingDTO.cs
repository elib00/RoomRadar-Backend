namespace RoomRadar_Backend.DTO
{
    public class CreateRatingDTO
    {
        public int UserId { get; set; }
        public int BoardingHouseId { get; set; }
        public int Star {  get; set; }
    }
}
