using RoomRadar_Backend.Models;

namespace RoomRadar_Backend.DTO
{
    public class ApiResponseDTO
    {
        public bool Success { get; set; }
        public string? Type { get; set; } //if error sha or success like passwords do not match or email not found
        public object? Data { get; set; }
    }
}
