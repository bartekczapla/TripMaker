using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class changeExternalServicesJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputJSON",
                table: "ExternalServicesJSON");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "PlanForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceType",
                table: "ExternalServicesJSON",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AddColumn<string>(
                name: "InputUri",
                table: "ExternalServicesJSON",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "PlanForms");

            migrationBuilder.DropColumn(
                name: "InputUri",
                table: "ExternalServicesJSON");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceType",
                table: "ExternalServicesJSON",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "InputJSON",
                table: "ExternalServicesJSON",
                maxLength: 8192,
                nullable: false,
                defaultValue: "");
        }
    }
}
