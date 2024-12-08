using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RoomRadar_Backend.Models
{
    public class PendingLandLord
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public User? LandLord { get; set; }
    }
}
