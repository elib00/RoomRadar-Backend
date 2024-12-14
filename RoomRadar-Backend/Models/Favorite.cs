using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RoomRadar_Backend.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        [ForeignKey("BoardingHouseId")]
        public int BoardingHouseId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public BoardingHouse? BoardingHouse { get; set; }
    }
}
