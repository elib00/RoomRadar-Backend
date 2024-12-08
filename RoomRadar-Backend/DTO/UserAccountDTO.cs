// File: UserAccountDTO.cs
using System.ComponentModel.DataAnnotations;

namespace RoomRadar_Backend.Models
{
    public class UserAccountDTO
    {

        [Required(ErrorMessage = "Lacking credentials. Email must be provided.")]
        public required string Email { get; set; }

        // Password is excluded here, as you wouldn't expose it in a DTO.
        // It will only be used for authentication purposes on the server.
    }

    // DTO for creating a UserAccount (if you want to exclude the Id for a POST request)
    public class CreateUserAccountDTO
    {
        [Required(ErrorMessage = "Lacking credentials. Email must be provided.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password must be provided.")]
        public required string Password { get; set; }
        public int UserId { get; set; }
    }

    // DTO for updating a UserAccount (if you want to allow partial updates)
    public class UpdateUserAccountDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
