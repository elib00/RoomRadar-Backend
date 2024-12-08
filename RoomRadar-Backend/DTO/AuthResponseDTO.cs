using RoomRadar_Backend.Models;

public class AuthResponseDTO
{
    public bool IsSuccess { get; set; }
    public string? Type { get; set; } //if error sha or success like passwords do not match or email not found
    public User? User { get; set; }
}
