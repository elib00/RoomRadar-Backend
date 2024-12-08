using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RoomRadar_Backend.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public bool IsLandLord { get; set; }
        [Required(ErrorMessage = "Lacking credentials. First name must be provided.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Lacking credentials. Last name must be provided.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Lacking credentials. Contact number must be provided.")]
        public required string ContactNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime BirthDate { get; set; }

        // navigation property para makuha si credentials, also for one-to-one relationship sheesh stick to one
        public LandLordCredentials? LandLordCredentials { get; set; }


        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }  // Foreign key for User

        // Navigation property to access the associated User
        [JsonIgnore]
        public User? User { get; set; }

    }
}
