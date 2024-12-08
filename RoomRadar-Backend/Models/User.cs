using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomRadar_Backend.Models
{
    //encapsulates UserAccount and UserProfile
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required UserAccount Account { get; set; }
        [Required]
        public required UserProfile Profile { get; set; }

    }
}
