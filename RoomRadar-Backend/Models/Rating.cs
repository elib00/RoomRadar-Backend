using System.ComponentModel.DataAnnotations.Schema;

namespace RoomRadar_Backend.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [ForeignKey("BoardingHouseId")]
        public int BoardingHouseId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public int Star {  get; set; }

        public User? User { get; set; }
        public BoardingHouse? BoardingHouse { get; set; }
    }
}
