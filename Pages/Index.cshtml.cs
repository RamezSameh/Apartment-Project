using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apartment_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Apartment_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;

        public IList<Apartment> Apartments { get; private set; } = new List<Apartment>();

        [BindProperty(SupportsGet = true)]
        public string? q { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? location { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? minPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? maxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public string sort { get; set; } = "recent";

        [BindProperty(SupportsGet = true)]
        public int page { get; set; } = 1;

        public int PageSize { get; } = 12;
        public int TotalItems { get; set; }

        // Popular locations for quick links
        public List<string> PopularLocations { get; } = new List<string>
        {
            "New York, NY", "Los Angeles, CA", "Chicago, IL", "Houston, TX", "Miami, FL"
        };

        public async Task OnGetAsync()
        {
            var query = _context.Apartments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                var term = q.Trim();
                query = query.Where(a => a.Title!.Contains(term) || (a.Description != null && a.Description.Contains(term)));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                var loc = location.Trim();
                query = query.Where(a => a.Location != null && a.Location.Contains(loc));
            }

            if (minPrice.HasValue) query = query.Where(a => a.Price >= minPrice.Value);
            if (maxPrice.HasValue) query = query.Where(a => a.Price <= maxPrice.Value);

            // Sorting
            query = sort switch
            {
                "price_asc" => query.OrderBy(a => a.Price),
                "price_desc" => query.OrderByDescending(a => a.Price),
                "available" => query.OrderByDescending(a => a.IsAvailable).ThenByDescending(a => a.ID),
                _ => query.OrderByDescending(a => a.ID) // recent
            };

            TotalItems = await query.CountAsync();

            Apartments = await query
                .Skip((Math.Max(1, page) - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}