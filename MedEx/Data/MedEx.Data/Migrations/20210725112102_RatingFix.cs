using Microsoft.EntityFrameworkCore.Migrations;

namespace MedEx.Data.Migrations
{
    public partial class RatingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RatingId",
                table: "Appointments",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Ratings_RatingId",
                table: "Appointments",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Ratings_RatingId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_RatingId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Appointments");
        }
    }
}
