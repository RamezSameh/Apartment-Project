using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apartment_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apartment_Project.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> GetApartments()
        {
            var apartments = await _context.Apartments.ToListAsync();
            return apartments.Select(ToDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApartmentDto>> GetApartment(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null) return NotFound();
            return ToDto(apartment);
        }

        [HttpPost]
        public async Task<ActionResult<ApartmentDto>> CreateApartment(ApartmentDto dto)
        {
            var apartment = new Apartment
            {
                Title = dto.Title,
                Location = dto.Location,
                Description = dto.Description,
                Price = dto.Price,
                IsAvailable = dto.IsAvailable,
                SomePhoto = DecodePhoto(dto.PhotoBase64)
            };

            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            dto.ID = apartment.ID;
            return CreatedAtAction(nameof(GetApartment), new { id = apartment.ID }, ToDto(apartment));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApartment(int id, ApartmentDto dto)
        {
            if (id != dto.ID) return BadRequest();

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null) return NotFound();

            apartment.Title = dto.Title;
            apartment.Location = dto.Location;
            apartment.Description = dto.Description;
            apartment.Price = dto.Price;
            apartment.IsAvailable = dto.IsAvailable;

            if (!string.IsNullOrWhiteSpace(dto.PhotoBase64))
            {
                apartment.SomePhoto = DecodePhoto(dto.PhotoBase64);
            }

            _context.Update(apartment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null) return NotFound();

            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id}/book")]
        public async Task<IActionResult> BookApartment(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null) return NotFound();
            if (apartment.IsAvailable)
            {
                apartment.IsAvailable = false;
                _context.Update(apartment);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        private static ApartmentDto ToDto(Apartment apartment)
        {
            return new ApartmentDto
            {
                ID = apartment.ID,
                Title = apartment.Title,
                Location = apartment.Location,
                Description = apartment.Description,
                Price = apartment.Price,
                IsAvailable = apartment.IsAvailable,
                PhotoBase64 = apartment.SomePhoto == null ? null : Convert.ToBase64String(apartment.SomePhoto)
            };
        }

        private static byte[]? DecodePhoto(string? base64)
        {
            if (string.IsNullOrWhiteSpace(base64)) return null;
            return Convert.FromBase64String(base64);
        }
    }
}
