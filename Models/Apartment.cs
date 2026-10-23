using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Apartment_Project.Models
{
    public class Apartment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public byte[]? SomePhoto { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public ListingType ListingType { get; set; } = ListingType.Rent;

        // Not mapped to the database — used only for binding uploaded file in forms
        [NotMapped]
        public IFormFile? PhotoFile { get; set; }
    }
}
