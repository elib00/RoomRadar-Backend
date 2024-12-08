using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RoomRadar_Backend.Models
{
    public class LandLordCredentials
    {
        public int Id { get; set; }

        [ForeignKey("UserProfileId")]
        [Required]
        public int UserProfileId { get; set; }

        //for a landlord credentials to exist, dapat naa jud kay user profile first
        public UserProfile? UserProfile { get; set; }

    }
}
