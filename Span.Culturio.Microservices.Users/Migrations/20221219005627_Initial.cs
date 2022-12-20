using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Span.Culturio.Microservices.Users.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, "admin@culturio.eu", "Admin", "User", new byte[] { 175, 226, 75, 100, 144, 142, 52, 78, 83, 36, 78, 1, 9, 17, 206, 210, 23, 124, 197, 21, 240, 212, 49, 16, 186, 100, 70, 184, 8, 39, 146, 183, 129, 253, 202, 226, 131, 191, 13, 138, 195, 197, 179, 231, 89, 44, 154, 44, 12, 221, 192, 20, 121, 161, 136, 197, 45, 161, 138, 196, 180, 127, 229, 251 }, new byte[] { 100, 4, 197, 56, 237, 197, 190, 138, 49, 74, 66, 219, 193, 224, 96, 105, 142, 91, 229, 12, 119, 142, 246, 49, 99, 190, 39, 67, 45, 53, 62, 176, 226, 133, 231, 68, 133, 156, 100, 74, 174, 110, 216, 159, 145, 36, 157, 41, 181, 158, 47, 227, 93, 73, 201, 184, 172, 120, 106, 153, 241, 117, 19, 13, 184, 33, 108, 62, 204, 69, 135, 210, 196, 171, 244, 62, 108, 62, 35, 55, 216, 74, 136, 107, 56, 50, 123, 69, 127, 130, 82, 204, 213, 59, 174, 220, 156, 77, 166, 245, 192, 198, 85, 228, 22, 183, 166, 75, 96, 111, 173, 90, 20, 172, 193, 206, 70, 190, 118, 144, 172, 215, 239, 173, 159, 222, 164, 151 }, "sysadmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
