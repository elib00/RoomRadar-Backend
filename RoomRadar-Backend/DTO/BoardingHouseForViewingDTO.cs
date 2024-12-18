﻿namespace RoomRadar_Backend.DTO
{
    public class BoardingHouseForViewingDTO
    {
        // to add rating table and isFavorite
        public double BoardingHouseId { get; set; }
        public string? BoardingHouseName {  get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Price { get; set; }
        public string? LandLordFirstName {  get; set; }
        public string? LandLordLastName { get; set; }
        public string? LandLordContactNumber {  get; set; }
        public int TruncatedAverageRating {  get; set; }
        public int TotalFavoritesFromUsers { get; set; }
    }
}
