using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Span.Culturio.Microservices.Users.Migrations
{
    public partial class Added_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "PlatformAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "CultureObjectAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[] { new byte[] { 77, 36, 218, 0, 94, 110, 89, 67, 81, 0, 185, 229, 24, 107, 128, 26, 69, 145, 166, 37, 47, 246, 136, 102, 251, 132, 173, 96, 22, 177, 163, 91, 245, 69, 136, 231, 145, 149, 90, 76, 115, 15, 90, 201, 128, 232, 32, 156, 147, 204, 158, 115, 239, 10, 67, 232, 97, 201, 213, 109, 122, 110, 114, 131 }, new byte[] { 165, 217, 234, 208, 205, 208, 239, 207, 125, 113, 185, 49, 122, 155, 232, 190, 225, 125, 98, 70, 248, 226, 105, 28, 198, 212, 184, 16, 40, 251, 110, 23, 22, 115, 52, 94, 166, 149, 37, 148, 115, 103, 25, 181, 123, 79, 181, 252, 147, 238, 0, 120, 41, 202, 232, 160, 170, 106, 188, 234, 147, 227, 46, 213, 193, 115, 87, 219, 101, 101, 250, 154, 78, 1, 181, 117, 193, 220, 16, 145, 197, 74, 104, 146, 84, 117, 205, 223, 58, 5, 75, 67, 159, 101, 190, 57, 153, 3, 105, 142, 220, 94, 223, 6, 87, 136, 130, 82, 138, 52, 72, 185, 3, 40, 227, 239, 146, 138, 45, 38, 170, 176, 45, 66, 21, 3, 157, 80 }, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 48, 46, 5, 19, 13, 164, 61, 175, 71, 158, 192, 161, 158, 250, 14, 38, 51, 183, 158, 80, 207, 132, 3, 217, 197, 147, 140, 26, 153, 184, 142, 0, 110, 195, 91, 72, 103, 102, 52, 107, 241, 83, 103, 65, 193, 90, 87, 58, 243, 147, 221, 130, 244, 188, 151, 46, 125, 196, 252, 2, 172, 137, 41, 127 }, new byte[] { 51, 58, 63, 28, 239, 93, 218, 202, 140, 20, 21, 128, 12, 173, 139, 251, 49, 186, 119, 49, 12, 139, 12, 241, 11, 52, 81, 202, 129, 0, 158, 3, 51, 150, 207, 165, 45, 222, 199, 57, 240, 3, 169, 174, 18, 184, 73, 78, 7, 239, 38, 90, 132, 50, 77, 244, 243, 7, 124, 73, 111, 66, 194, 207, 126, 24, 223, 208, 242, 198, 193, 41, 121, 80, 59, 215, 198, 118, 36, 236, 19, 179, 168, 29, 58, 14, 182, 171, 12, 132, 23, 42, 22, 172, 151, 224, 216, 206, 68, 221, 181, 218, 66, 207, 16, 41, 43, 190, 16, 245, 201, 225, 212, 217, 1, 129, 63, 2, 62, 210, 233, 218, 207, 168, 167, 127, 228, 87 } });
        }
    }
}
