using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristToursAppWeb.Data.Migrations
{
    public partial class changeColumInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "TourBookings");

            migrationBuilder.RenameColumn(
                name: "IsRefused",
                table: "TourBookings",
                newName: "Actions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 8, 14, 26, 41, 611, DateTimeKind.Utc).AddTicks(5050),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 14, 55, 36, 493, DateTimeKind.Utc).AddTicks(8829));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Actions",
                table: "TourBookings",
                newName: "IsRefused");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 14, 55, 36, 493, DateTimeKind.Utc).AddTicks(8829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 8, 14, 26, 41, 611, DateTimeKind.Utc).AddTicks(5050));

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "TourBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
