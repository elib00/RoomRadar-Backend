using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomRadar_Backend.Models
{
    //encapsulates UserAccount and UserProfile
    public class User
    {
        public int Id { get; set; }

        [Required]
        public required UserAccount Account { get; set; }
        [Required]
        public required UserProfile Profile { get; set; }

    }

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
        public required User User { get; set; }
    }

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
        public DateTime BirthDate {  get; set; }

        // navigation property para makuha si credentials, also for one-to-one relationship sheesh stick to one
        public LandLordCredentials? LandLordCredentials { get; set; }


        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }  // Foreign key for User

        // Navigation property to access the associated User
        public required User User { get; set; }

    }

    public class LandLordCredentials
    {
        public int Id { get; set; }

        [ForeignKey("UserProfileId")]
        [Required]
        public int UserProfileId {  get; set; }
        
        //for a landlord credentials to exist, dapat naa jud kay user profile first
        public required UserProfile UserProfile { get; set; }
        
    }
}
