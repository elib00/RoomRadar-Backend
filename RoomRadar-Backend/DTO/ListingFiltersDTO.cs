namespace RoomRadar_Backend.DTO
{
    public class ListingFiltersDTO
    {
        public string PropertyType { get; set; }
        public double PriceRange { get; set; }
        public List<string> Amenities {  get; set; }
        public bool AllowPets {  get; set; }
        public List<string> AdditionalFees {  get; set; }

        public string SortBy {  get; set; }
    }
}
