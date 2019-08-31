using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class PlanElementTypesAndPlanElementOpeningHours7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Plans");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Plans");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Plans",
                nullable: true);
        }
    }
}
