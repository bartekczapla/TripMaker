using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class UpdatePlanInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Plans",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Lat",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Lng",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalUserReviews",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "PlanAccomodations",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalUserReviews",
                table: "PlanAccomodations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "TotalUserReviews",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "PlanAccomodations");

            migrationBuilder.DropColumn(
                name: "TotalUserReviews",
                table: "PlanAccomodations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Plans",
                newName: "Destination");
        }
    }
}
