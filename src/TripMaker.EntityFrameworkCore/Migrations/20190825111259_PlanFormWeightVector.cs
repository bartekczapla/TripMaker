using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class PlanFormWeightVector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanForms_PlanAccomodations_PlanAccomodationId",
                table: "PlanForms");

            migrationBuilder.DropIndex(
                name: "IX_PlanForms_PlanAccomodationId",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "PlanAccomodationId",
                table: "PlanForms");

            migrationBuilder.AddColumn<int>(
                name: "PlanAccomodationId",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanFormWeightVectorId",
                table: "Plans",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SortedPlanElementsString",
                table: "PlanForms",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PreferedTravelModesString",
                table: "PlanForms",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PreferedPlanElementsString",
                table: "PlanForms",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "PlanFormWeightVectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false),
                    Distance = table.Column<decimal>(nullable: false),
                    Popularity = table.Column<decimal>(nullable: false),
                    Entertainment = table.Column<decimal>(nullable: false),
                    Relax = table.Column<decimal>(nullable: false),
                    Activity = table.Column<decimal>(nullable: false),
                    Culture = table.Column<decimal>(nullable: false),
                    Sightseeing = table.Column<decimal>(nullable: false),
                    Partying = table.Column<decimal>(nullable: false),
                    Shopping = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanFormWeightVectors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PlanAccomodationId",
                table: "Plans",
                column: "PlanAccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PlanFormWeightVectorId",
                table: "Plans",
                column: "PlanFormWeightVectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_PlanAccomodations_PlanAccomodationId",
                table: "Plans",
                column: "PlanAccomodationId",
                principalTable: "PlanAccomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_PlanFormWeightVectors_PlanFormWeightVectorId",
                table: "Plans",
                column: "PlanFormWeightVectorId",
                principalTable: "PlanFormWeightVectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_PlanAccomodations_PlanAccomodationId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_PlanFormWeightVectors_PlanFormWeightVectorId",
                table: "Plans");

            migrationBuilder.DropTable(
                name: "PlanFormWeightVectors");

            migrationBuilder.DropIndex(
                name: "IX_Plans_PlanAccomodationId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_PlanFormWeightVectorId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanAccomodationId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanFormWeightVectorId",
                table: "Plans");

            migrationBuilder.AlterColumn<string>(
                name: "SortedPlanElementsString",
                table: "PlanForms",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PreferedTravelModesString",
                table: "PlanForms",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PreferedPlanElementsString",
                table: "PlanForms",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "PlanAccomodationId",
                table: "PlanForms",
                nullable: true);

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
    }
}
