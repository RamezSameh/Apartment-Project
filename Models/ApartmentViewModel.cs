using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Apartment_Project.Models
{
    public class ApartmentViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Location { get; set; }

        public string? Description { get; set; }

        // Existing photo bytes for preview in Edit
        public byte[]? ExistingPhoto { get; set; }

        // File uploaded by user
        public IFormFile? PhotoFile { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public bool IsAvailable { get; set; }
    }
}