namespace RoomRadar_Backend.DTO
{
    public class BoardingHouseListingDTO
    {
        public int Id { get; set; }
        public string? PropertyName { get; set; }

        // Flattened Address properties
        public string? Street { get; set; }
        public string? Barangay { get; set; }
        public string? Municipality { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }

        // Flattened Location properties
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string? PropertyType { get; set; }
        public List<string> RulesArray { get; set; }
        public int NumOfBeds { get; set; }
        public int NumOfBedrooms { get; set; }
        public int NumOfBathrooms { get; set; }
        public double MonthlyRate { get; set; }
        public int LandLordId { get; set; }
        public string? Description { get; set; }
        public List<string> AmenitiesArray { get; set; }
        public bool AllowPets { get; set; }
        public List<string> AdditionalFeesArray { get; set; }
    }
}