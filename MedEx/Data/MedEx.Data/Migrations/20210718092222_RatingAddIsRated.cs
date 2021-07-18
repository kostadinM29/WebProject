using Microsoft.EntityFrameworkCore.Migrations;

namespace MedEx.Data.Migrations
{
    public partial class RatingAddIsRated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRated",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRated",
                table: "Appointments");
        }
    }
}
