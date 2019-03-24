using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class PlanAccomodation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanAccomodationId",
                table: "PlanForms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanAccomodations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    PlaceId = table.Column<string>(maxLength: 128, nullable: true),
                    PlaceName = table.Column<string>(maxLength: 128, nullable: true),
                    FormattedAddress = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAccomodations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanForms_PlanAccomodationId",
                table: "PlanForms",
                column: "PlanAccomodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanForms_PlanAccomodations_PlanAccomodationId",
                table: "PlanForms",
                column: "PlanAccomodationId",
                principalTable: "PlanAccomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanForms_PlanAccomodations_PlanAccomodationId",
                table: "PlanForms");

            migrationBuilder.DropTable(
                name: "PlanAccomodations");

            migrationBuilder.DropIndex(
                name: "IX_PlanForms_PlanAccomodationId",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "PlanAccomodationId",
                table: "PlanForms");
        }
    }
}
