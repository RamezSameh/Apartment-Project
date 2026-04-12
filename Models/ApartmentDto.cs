namespace Apartment_Project.Models
{
    public class ApartmentDto
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string? PhotoBase64 { get; set; }
    }
}
