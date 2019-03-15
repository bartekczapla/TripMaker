using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanElements_Plans_PlanId",
                table: "PlanElements");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "PlanElements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ElementType",
                table: "PlanElements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "PlanElements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "PlanElements",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "PlanElements",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                table: "PlanElements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlaceId",
                table: "PlanElements",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "PlanElements",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "PlanElements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_PlanElements_Plans_PlanId",
                table: "PlanElements",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanElements_Plans_PlanId",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "ElementType",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "End",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "PlanElements");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "PlanElements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanElements_Plans_PlanId",
                table: "PlanElements",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
