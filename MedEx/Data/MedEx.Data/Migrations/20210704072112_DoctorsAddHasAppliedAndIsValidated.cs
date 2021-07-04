using Microsoft.EntityFrameworkCore.Migrations;

namespace MedEx.Data.Migrations
{
    public partial class DoctorsAddHasAppliedAndIsValidated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasApplied",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsValidated",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasApplied",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsValidated",
                table: "Doctors");
        }
    }
}
