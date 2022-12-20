using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Span.Culturio.Microservices.Subscriptions.Migrations
{
    public partial class AddTrackVisits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackVisit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    CultureObjectId = table.Column<int>(type: "int", nullable: false),
                    TimeEntered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackVisit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackVisit");
        }
    }
}
