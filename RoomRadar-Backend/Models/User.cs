using System.ComponentModel.DataAnnotations;

namespace RoomRadar_Backend.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lacking credentials. First name must be provided.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Lacking credentials. Last name must be provided.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Lacking credentials. Email must be provided.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Lacking credentials. Contact number must be provided.")]
        public required string ContactNumber { get; set; }
        
        public bool IsLandLord { get; set; }
    }
}
