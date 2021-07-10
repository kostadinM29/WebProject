using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MedEx.Data.Migrations
{
    public partial class AppointmentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitingTime",
                table: "Appointments");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Appointments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSalonRatedByTheUser",
                table: "Appointments",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsSalonRatedByTheUser",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "VisitingTime",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
