using Microsoft.EntityFrameworkCore.Migrations;

namespace MedEx.Data.Migrations
{
    public partial class AddTownToPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TownId",
                table: "Patients",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Towns_TownId",
                table: "Patients",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Towns_TownId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_TownId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Patients");
        }
    }
}
