using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class Plan_Form_Element : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "HasAccomodationBooked",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "HasJourneyBooked",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Plans");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Plans",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlanFormId",
                table: "Plans",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanElements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaceName = table.Column<string>(maxLength: 128, nullable: true),
                    PlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanElements_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaceName = table.Column<string>(maxLength: 512, nullable: false),
                    PlaceId = table.Column<string>(maxLength: 512, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: true),
                    HasJourneyBooked = table.Column<bool>(nullable: false),
                    HasAccomodationBooked = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanForms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PlanFormId",
                table: "Plans",
                column: "PlanFormId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanElements_PlanId",
                table: "PlanElements",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_PlanForms_PlanFormId",
                table: "Plans",
                column: "PlanFormId",
                principalTable: "PlanForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_PlanForms_PlanFormId",
                table: "Plans");

            migrationBuilder.DropTable(
                name: "PlanElements");

            migrationBuilder.DropTable(
                name: "PlanForms");

            migrationBuilder.DropIndex(
                name: "IX_Plans_PlanFormId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanFormId",
                table: "Plans");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Plans",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "HasAccomodationBooked",
                table: "Plans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasJourneyBooked",
                table: "Plans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PlaceId",
                table: "Plans",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "Plans",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Plans",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
