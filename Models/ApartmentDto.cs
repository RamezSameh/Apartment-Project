namespace Apartment_Project.Models
{
    public class ApartmentDto
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public ListingType ListingType { get; set; } = ListingType.Rent;
        public string? PhotoBase64 { get; set; }
    }
}
