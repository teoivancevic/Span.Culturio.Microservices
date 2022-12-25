using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Span.Culturio.Microservices.Packages.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "Id", "Name", "ValidDays" },
                values: new object[] { 1, "Muzeji", 15 });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "Id", "Name", "ValidDays" },
                values: new object[] { 2, "Kino", 30 });

            migrationBuilder.InsertData(
                table: "PackageCultureObject",
                columns: new[] { "Id", "AvailableVisits", "CultureObjectId", "PackageId" },
                values: new object[] { 1, 3, 1, 1 });

            migrationBuilder.InsertData(
                table: "PackageCultureObject",
                columns: new[] { "Id", "AvailableVisits", "CultureObjectId", "PackageId" },
                values: new object[] { 2, 5, 2, 2 });

            migrationBuilder.InsertData(
                table: "PackageCultureObject",
                columns: new[] { "Id", "AvailableVisits", "CultureObjectId", "PackageId" },
                values: new object[] { 3, 2, 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageCultureObject",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PackageCultureObject",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PackageCultureObject",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Package",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Package",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
