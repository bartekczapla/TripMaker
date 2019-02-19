using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class addplaceNametoSearchedPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PlaceId",
                table: "SearchedPlace",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "SearchedPlace",
                maxLength: 512,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "SearchedPlace");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceId",
                table: "SearchedPlace",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 512);
        }
    }
}
