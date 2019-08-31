using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class PlanElementTypesAndPlanElementOpeningHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElementType",
                table: "PlanElements",
                newName: "ScorePosition");

            migrationBuilder.AlterColumn<double>(
                name: "Lng",
                table: "Plans",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Lat",
                table: "Plans",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "PlanElements",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormattedAddress",
                table: "PlanElements",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NormalizedScore",
                table: "PlanElements",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Popularity",
                table: "PlanElements",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PlanElements",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanElementOpeningHourEntityEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayOpen = table.Column<int>(nullable: false),
                    DayClose = table.Column<int>(nullable: true),
                    Open = table.Column<TimeSpan>(nullable: false),
                    Close = table.Column<TimeSpan>(nullable: true),
                    PlanElementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanElementOpeningHourEntityEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanElementOpeningHourEntityEntities_PlanElements_PlanElementId",
                        column: x => x.PlanElementId,
                        principalTable: "PlanElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanElementyTypeEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElementType = table.Column<int>(nullable: false),
                    PlanElementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanElementyTypeEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanElementyTypeEntities_PlanElements_PlanElementId",
                        column: x => x.PlanElementId,
                        principalTable: "PlanElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanElementOpeningHourEntityEntities_PlanElementId",
                table: "PlanElementOpeningHourEntityEntities",
                column: "PlanElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanElementyTypeEntities_PlanElementId",
                table: "PlanElementyTypeEntities",
                column: "PlanElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanElementOpeningHourEntityEntities");

            migrationBuilder.DropTable(
                name: "PlanElementyTypeEntities");

            migrationBuilder.DropColumn(
                name: "FormattedAddress",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "NormalizedScore",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PlanElements");

            migrationBuilder.RenameColumn(
                name: "ScorePosition",
                table: "PlanElements",
                newName: "ElementType");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lng",
                table: "Plans",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Plans",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "PlanElements",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
