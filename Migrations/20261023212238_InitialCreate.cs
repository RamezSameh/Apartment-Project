using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apartment_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SomePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ListingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "ID", "Description", "IsAvailable", "ListingType", "Location", "Price", "SomePhoto", "Title" },
                values: new object[,]
                {
                    { 1, "Beautiful studio apartment with floor-to-ceiling windows and modern amenities.", true, 0, "Downtown, New York", 2500, null, "Modern Downtown Studio" },
                    { 2, "Charming one-bedroom apartment with exposed brick and hardwood floors.", true, 0, "Brooklyn, New York", 2800, null, "Cozy Brooklyn One Bedroom" },
                    { 3, "Stunning penthouse with panoramic city views and premium finishes.", false, 1, "Manhattan, New York", 5500, null, "Luxury Manhattan Penthouse" },
                    { 4, "Large two-bedroom apartment perfect for families.", true, 0, "Queens, New York", 2200, null, "Spacious Queens Family Home" },
                    { 5, "Contemporary apartment with river views and modern kitchen.", true, 1, "Upper West Side, New York", 3200, null, "Riverside Apartment" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
