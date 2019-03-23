using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class AddAllPlanTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Language = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalServicesJSON",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceType = table.Column<int>(nullable: false),
                    InputUri = table.Column<string>(maxLength: 256, nullable: false),
                    ResultJSON = table.Column<string>(maxLength: 16384, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Destination = table.Column<string>(maxLength: 128, nullable: false),
                    PlanFormId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Comment = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_PlanForms_PlanFormId",
                        column: x => x.PlanFormId,
                        principalTable: "PlanForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanElements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaceName = table.Column<string>(maxLength: 128, nullable: true),
                    PlaceId = table.Column<string>(maxLength: 128, nullable: true),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    ElementType = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: true),
                    PlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanElements_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distance = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    StartPlanElementId = table.Column<int>(nullable: true),
                    EndPlanElementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanRoutes_PlanElements_EndPlanElementId",
                        column: x => x.EndPlanElementId,
                        principalTable: "PlanElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanRoutes_PlanElements_StartPlanElementId",
                        column: x => x.StartPlanElementId,
                        principalTable: "PlanElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanRouteSteps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distance = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    StartStepLat = table.Column<double>(nullable: false),
                    StartStepLng = table.Column<double>(nullable: false),
                    EndStepLat = table.Column<double>(nullable: false),
                    EndStepLng = table.Column<double>(nullable: false),
                    HtmlInstruction = table.Column<string>(maxLength: 65536, nullable: true),
                    TravelMode = table.Column<int>(nullable: false),
                    Maneuver = table.Column<string>(maxLength: 64, nullable: true),
                    PlanRouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanRouteSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanRouteSteps_PlanRoutes_PlanRouteId",
                        column: x => x.PlanRouteId,
                        principalTable: "PlanRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalServicesJSON_PlanFormId",
                table: "ExternalServicesJSON",
                column: "PlanFormId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanElements_PlanId",
                table: "PlanElements",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanRoutes_EndPlanElementId",
                table: "PlanRoutes",
                column: "EndPlanElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanRoutes_StartPlanElementId",
                table: "PlanRoutes",
                column: "StartPlanElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanRouteSteps_PlanRouteId",
                table: "PlanRouteSteps",
                column: "PlanRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PlanFormId",
                table: "Plans",
                column: "PlanFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserId",
                table: "Plans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalServicesJSON");

            migrationBuilder.DropTable(
                name: "PlanRouteSteps");

            migrationBuilder.DropTable(
                name: "PlanRoutes");

            migrationBuilder.DropTable(
                name: "PlanElements");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "PlanForms");
        }
    }
}
