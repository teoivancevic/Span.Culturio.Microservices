using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Span.Culturio.Microservices.Subscriptions.Migrations
{
    public partial class AddSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActiveFrom", "ActiveTo" },
                values: new object[] { new DateTime(2022, 12, 20, 23, 45, 49, 126, DateTimeKind.Local).AddTicks(9960), new DateTime(2022, 12, 20, 23, 45, 49, 126, DateTimeKind.Local).AddTicks(9980) });

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActiveFrom", "ActiveTo" },
                values: new object[] { new DateTime(2022, 12, 20, 23, 45, 49, 126, DateTimeKind.Local).AddTicks(9990), new DateTime(2022, 12, 20, 23, 45, 49, 126, DateTimeKind.Local).AddTicks(9990) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActiveFrom", "ActiveTo" },
                values: new object[] { new DateTime(2022, 12, 20, 23, 44, 39, 92, DateTimeKind.Local).AddTicks(2040), new DateTime(2022, 12, 20, 23, 44, 39, 92, DateTimeKind.Local).AddTicks(2070) });

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActiveFrom", "ActiveTo" },
                values: new object[] { new DateTime(2022, 12, 20, 23, 44, 39, 92, DateTimeKind.Local).AddTicks(2080), new DateTime(2022, 12, 20, 23, 44, 39, 92, DateTimeKind.Local).AddTicks(2080) });
        }
    }
}
