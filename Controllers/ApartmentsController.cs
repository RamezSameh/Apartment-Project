using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apartment_Project.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Apartment_Project.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Allowed image types and max size
        private static readonly HashSet<string> AllowedImageContentTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "image/jpeg",
            "image/png",
            "image/gif",
            "image/webp"
        };
        private const long MaxImageBytes = 5 * 1024 * 1024; // 5 MB

        public ApartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Apartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apartments.ToListAsync());
        }

        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var apartment = await _context.Apartments.FirstOrDefaultAsync(m => m.ID == id);
            if (apartment == null) return NotFound();   

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            List<string> apartTitle = new List<string> { "Apartment", "Market" };
            ViewBag.apt = apartTitle;
            return View();
        }

        // POST: Apartments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Location,Description,Price,IsAvailable,ListingType,PhotoFile")] Apartment apartment)
        {
            // Validate uploaded file (if present)
            if (apartment.PhotoFile != null)
            {
                if (!IsValidImageFile(apartment.PhotoFile, out var error))
                {
                    ModelState.AddModelError("PhotoFile", error);
                }
            }

            if (ModelState.IsValid)
            {
                if (apartment.PhotoFile != null && apartment.PhotoFile.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await apartment.PhotoFile.CopyToAsync(ms);
                    apartment.SomePhoto = ms.ToArray();
                }

                _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apartment);
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null) return NotFound();
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Location,Description,Price,IsAvailable,ListingType,PhotoFile")] Apartment apartment)
        {
            if (id != apartment.ID) return NotFound();

            // Validate uploaded file (if present)
            if (apartment.PhotoFile != null)
            {
                if (!IsValidImageFile(apartment.PhotoFile, out var error))
                {
                    ModelState.AddModelError("PhotoFile", error);
                }
            }

            if (!ModelState.IsValid)
            {
                return View(apartment);
            }

            var existing = await _context.Apartments.FindAsync(id);
            if (existing == null) return NotFound();

            // Update scalar fields
            existing.Title = apartment.Title;
            existing.Location = apartment.Location;
            existing.Description = apartment.Description;
            existing.Price = apartment.Price;
            existing.IsAvailable = apartment.IsAvailable;
            existing.ListingType = apartment.ListingType;

            // Replace photo only when a valid new file was uploaded
            if (apartment.PhotoFile != null && apartment.PhotoFile.Length > 0)
            {
                using var ms = new MemoryStream();
                await apartment.PhotoFile.CopyToAsync(ms);
                existing.SomePhoto = ms.ToArray();
            }

            try
            {
                _context.Update(existing);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(existing.ID)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var apartment = await _context.Apartments.FirstOrDefaultAsync(m => m.ID == id);
            if (apartment == null) return NotFound();

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null) return NotFound();

            _context.Remove(apartment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Book(int? id)
        {
            if (id == null) return NotFound();

            var apartment = await _context.Apartments.FirstOrDefaultAsync(m => m.ID == id);
            if (apartment == null) return NotFound();

            if (apartment.IsAvailable)
            {
                apartment.IsAvailable = false;
                _context.Update(apartment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartments.Any(e => e.ID == id);
        }

        private bool IsValidImageFile(IFormFile file, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (file == null) return true;

            if (file.Length == 0)
            {
                errorMessage = "The uploaded file is empty.";
                return false;
            }

            if (file.Length > MaxImageBytes)
            {
                errorMessage = $"The uploaded file exceeds the maximum allowed size of {MaxImageBytes / (1024 * 1024)} MB.";
                return false;
            }

            if (!AllowedImageContentTypes.Contains(file.ContentType))
            {
                errorMessage = "Only image files (jpeg, png, gif, webp) are allowed.";
                return false;
            }

            return true;
        }
    }
}
