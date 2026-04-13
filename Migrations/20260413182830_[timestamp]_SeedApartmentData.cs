using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment_Project.Migrations
{
    /// <inheritdoc />
    public partial class timestamp_SeedApartmentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Title", "Location", "Description", "Price", "IsAvailable" },
                values: new object[,]
                {
                    // Manhattan - Premium Locations
                    { "Modern Downtown Studio", "Downtown Manhattan, New York", "Beautiful studio apartment with floor-to-ceiling windows and modern amenities.", 2500m, true },
                    { "Luxury Manhattan Penthouse", "Upper East Side, Manhattan", "Stunning penthouse with panoramic city views and premium finishes.", 5500m, false },
                    { "Midtown Professional Suite", "Midtown Manhattan, New York", "Contemporary 1-bedroom near Central Park with doorman service.", 3800m, true },
                    { "SoHo Loft", "SoHo, Manhattan", "Industrial-style loft with exposed brick and high ceilings.", 4200m, true },
                    { "Times Square View Apartment", "Times Square, Manhattan", "Bright 2-bedroom with iconic city views.", 4500m, true },
                    
                    // Brooklyn - Trendy Areas
                    { "Cozy Brooklyn One Bedroom", "Williamsburg, Brooklyn", "Charming one-bedroom apartment with exposed brick and hardwood floors.", 2800m, true },
                    { "Hipster Brooklyn Studio", "Bushwick, Brooklyn", "Trendy studio in the heart of creative Brooklyn.", 2100m, true },
                    { "Park Slope Family Home", "Park Slope, Brooklyn", "Spacious 3-bedroom brownstone near Prospect Park.", 3500m, true },
                    { "DUMBO Waterfront Loft", "DUMBO, Brooklyn", "Modern loft with Manhattan skyline views.", 4000m, false },
                    { "Carroll Gardens Victorian", "Carroll Gardens, Brooklyn", "Historic townhouse with garden and outdoor space.", 3200m, true },
                    
                    // Queens - Affordable Options
                    { "Spacious Queens Family Home", "Forest Hills, Queens", "Large 2-bedroom apartment perfect for families.", 2200m, true },
                    { "Astoria Modern Apartment", "Astoria, Queens", "New construction with gym and rooftop access.", 2400m, true },
                    { "Jackson Heights Studio", "Jackson Heights, Queens", "Cozy studio in diverse, vibrant neighborhood.", 1800m, true },
                    { "Long Island City Luxury", "Long Island City, Queens", "Contemporary apartment overlooking East River.", 3100m, true },
                    { "Flushing Modern Living", "Flushing, Queens", "New 1-bedroom with excellent transit access.", 2000m, true },
                    
                    // Upper West Side
                    { "Riverside Apartment", "Upper West Side, New York", "Contemporary apartment with river views and modern kitchen.", 3200m, true },
                    { "Lincoln Center Adjacent", "Upper West Side, New York", "Pre-war charm with original hardwood floors near Lincoln Center.", 3600m, true },
                    { "Cathedral Parkway Studio", "Upper West Side, New York", "Bright studio with natural light and high ceiling.", 2300m, true },
                    
                    // Upper East Side
                    { "Museum Mile Apartment", "Upper East Side, New York", "Elegant 2-bedroom near world-class museums.", 4100m, true },
                    { "Lexington Avenue Residence", "Upper East Side, New York", "Doorman building with gym and laundry facilities.", 3900m, true },
                    { "Yorkville Studio", "Yorkville, New York", "Affordable studio in quieter East Side neighborhood.", 2100m, true },
                    
                    // Lower East Side / East Village
                    { "East Village Artistic Loft", "East Village, New York", "Spacious 2-bedroom artist's loft with exposed pipes.", 3300m, true },
                    { "Lower East Side Renovated", "Lower East Side, New York", "Newly renovated 1-bedroom with stainless steel appliances.", 2900m, true },
                    { "Chinatown Cozy Studio", "Chinatown, New York", "Budget-friendly studio in vibrant cultural neighborhood.", 1600m, true },
                    
                    // West Village / Greenwich Village
                    { "West Village Townhouse", "West Village, New York", "Charming 1-bedroom in tree-lined street.", 4300m, false },
                    { "Greenwich Village Garden Apt", "Greenwich Village, New York", "Rare garden apartment with private outdoor space.", 3700m, true },
                    
                    // Financial District / Battery Park
                    { "Wall Street Executive Suite", "Financial District, New York", "Modern high-rise with business center and 24-hour security.", 4000m, true },
                    { "Battery Park City Residence", "Battery Park City, New York", "Luxury apartment with park views and waterfront access.", 4600m, true },
                    
                    // Astoria/Long Island City (Queens continued)
                    { "Queensboro Plaza Studio", "Astoria, Queens", "Convenient studio near major transportation hub.", 1900m, true },
                    { "Gantry Plaza Waterfront", "Long Island City, Queens", "Stunning waterfront location with promenade access.", 3400m, true },
                    
                    // Additional Diverse Locations
                    { "Harlem Renaissance Loft", "Harlem, New York", "Spacious 2-bedroom in culturally rich neighborhood.", 2300m, true },
                    { "Washington Heights Apartment", "Washington Heights, New York", "Affordable family apartment with bridge views.", 1900m, true },
                    { "Inwood Historic Building", "Inwood, New York", "Pre-war charm in emerging northern Manhattan neighborhood.", 2000m, true },
                    { "Red Hook Industrial Loft", "Red Hook, Brooklyn", "Large converted warehouse loft with skylights.", 3800m, true },
                    { "Sunset Park Modern", "Sunset Park, Brooklyn", "New construction near Prospect Expressway.", 2600m, true },
                    { "Bay Ridge Classic", "Bay Ridge, Brooklyn", "Classic Brooklyn brownstone with backyard.", 2400m, true },
                    { "Kensington Family Space", "Kensington, Brooklyn", "Spacious 3-bedroom near Prospect Park.", 2700m, true },
                    { "Ridgewood Trendy Loft", "Ridgewood, Queens", "Hip neighborhood apartment with exposed brick.", 2500m, true },
                    { "Sunnyside Garden Apartment", "Sunnyside, Queens", "Quiet apartment near beautiful garden community.", 2200m, true },
                    { "Jackson Avenue Studio", "Astoria, Queens", "Compact studio with excellent neighborhood feel.", 1700m, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove all inserted apartments by matching on unique columns (e.g., Title and Location)
            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumns: new[] { "Title", "Location" },
                keyValues: new object[,]
                {
                    { "Modern Downtown Studio", "Downtown Manhattan, New York" },
                    { "Luxury Manhattan Penthouse", "Upper East Side, Manhattan" },
                    { "Midtown Professional Suite", "Midtown Manhattan, New York" },
                    { "SoHo Loft", "SoHo, Manhattan" },
                    { "Times Square View Apartment", "Times Square, Manhattan" },
                    { "Cozy Brooklyn One Bedroom", "Williamsburg, Brooklyn" },
                    { "Hipster Brooklyn Studio", "Bushwick, Brooklyn" },
                    { "Park Slope Family Home", "Park Slope, Brooklyn" },
                    { "DUMBO Waterfront Loft", "DUMBO, Brooklyn" },
                    { "Carroll Gardens Victorian", "Carroll Gardens, Brooklyn" },
                    { "Spacious Queens Family Home", "Forest Hills, Queens" },
                    { "Astoria Modern Apartment", "Astoria, Queens" },
                    { "Jackson Heights Studio", "Jackson Heights, Queens" },
                    { "Long Island City Luxury", "Long Island City, Queens" },
                    { "Flushing Modern Living", "Flushing, Queens" },
                    { "Riverside Apartment", "Upper West Side, New York" },
                    { "Lincoln Center Adjacent", "Upper West Side, New York" },
                    { "Cathedral Parkway Studio", "Upper West Side, New York" },
                    { "Museum Mile Apartment", "Upper East Side, New York" },
                    { "Lexington Avenue Residence", "Upper East Side, New York" },
                    { "Yorkville Studio", "Yorkville, New York" },
                    { "East Village Artistic Loft", "East Village, New York" },
                    { "Lower East Side Renovated", "Lower East Side, New York" },
                    { "Chinatown Cozy Studio", "Chinatown, New York" },
                    { "West Village Townhouse", "West Village, New York" },
                    { "Greenwich Village Garden Apt", "Greenwich Village, New York" },
                    { "Wall Street Executive Suite", "Financial District, New York" },
                    { "Battery Park City Residence", "Battery Park City, New York" },
                    { "Queensboro Plaza Studio", "Astoria, Queens" },
                    { "Gantry Plaza Waterfront", "Long Island City, Queens" },
                    { "Harlem Renaissance Loft", "Harlem, New York" },
                    { "Washington Heights Apartment", "Washington Heights, New York" },
                    { "Inwood Historic Building", "Inwood, New York" },
                    { "Red Hook Industrial Loft", "Red Hook, Brooklyn" },
                    { "Sunset Park Modern", "Sunset Park, Brooklyn" },
                    { "Bay Ridge Classic", "Bay Ridge, Brooklyn" },
                    { "Kensington Family Space", "Kensington, Brooklyn" },
                    { "Ridgewood Trendy Loft", "Ridgewood, Queens" },
                    { "Sunnyside Garden Apartment", "Sunnyside, Queens" },
                    { "Jackson Avenue Studio", "Astoria, Queens" }
                });
        }
    }
}
