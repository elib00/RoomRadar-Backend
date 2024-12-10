using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RoomRadar_Backend.Models
{
    public class BoardingHouse
    {
        [Key]
        public int Id { get; set; }
        public string? PropertyName { get; set; }
        [Required]
        public Address? Address { get; set; } // Owned type
        public string? PropertyType {  get; set; }
        public string? RulesJson { get; set; }
        public int NumOfBeds {  get; set; }
        public int NumOfBedrooms {  get; set; }
        public int NumOfBathrooms { get; set; }
        public double MonthlyRate { get; set; }
        [Required]
        public Location? Location { get; set; }

        [ForeignKey("LandLordId")]
        [Required]
        public int LandLordId { get; set; }
        public User? LandLord { get; set; }
        public string? Description {  get; set; }
        public string? AmenitiesJson {  get; set; }
        public bool AllowPets { get; set; }
        public string? AdditionalFeesJson {  get; set; }
        //initialize to prevent null checks
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }

    [Owned]
    public class Address
    {
        public string? Street { get; set; }
        public string? Barangay { get; set; }
        public string? Municipality { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
    }

    [Owned]
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
