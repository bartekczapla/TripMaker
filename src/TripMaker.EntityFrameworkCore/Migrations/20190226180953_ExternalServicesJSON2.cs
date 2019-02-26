using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class ExternalServicesJSON2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalServicesJSON",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceType = table.Column<string>(maxLength: 80, nullable: false),
                    InputJSON = table.Column<string>(maxLength: 8192, nullable: false),
                    ResultJSON = table.Column<string>(maxLength: 8192, nullable: false),
                    PlanFormId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalServicesJSON", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalServicesJSON_PlanForms_PlanFormId",
                        column: x => x.PlanFormId,
                        principalTable: "PlanForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalServicesJSON_PlanFormId",
                table: "ExternalServicesJSON",
                column: "PlanFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalServicesJSON");
        }
    }
}
