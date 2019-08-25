using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class ExtendPlanForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasJourneyBooked",
                table: "PlanForms");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "PlanForms",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "PlanForms",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccomodationId",
                table: "PlanForms",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AtractionDurationPreference",
                table: "PlanForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AtractionPopularityPreference",
                table: "PlanForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AverageSleep",
                table: "PlanForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistanceTypePreference",
                table: "PlanForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodPreference",
                table: "PlanForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxWalkingKmsPerDay",
                table: "PlanForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PreferedPlanElementsString",
                table: "PlanForms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferedTravelModesString",
                table: "PlanForms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PricePreference",
                table: "PlanForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SortedPlanElementsString",
                table: "PlanForms",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccomodationId",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "AtractionDurationPreference",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "AtractionPopularityPreference",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "AverageSleep",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "DistanceTypePreference",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "FoodPreference",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "MaxWalkingKmsPerDay",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "PreferedPlanElementsString",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "PreferedTravelModesString",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "PricePreference",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "SortedPlanElementsString",
                table: "PlanForms");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "PlanForms",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "PlanForms",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AddColumn<bool>(
                name: "HasJourneyBooked",
                table: "PlanForms",
                nullable: false,
                defaultValue: false);
        }
    }
}
