using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RoomRadar_Backend.Models
{
    //for auth
    public class UserAccount    
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lacking credentials. Email must be provided.")]
        public required string Email { get; set; }
        public required string Password { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }

}
