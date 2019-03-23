using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class RoutesNavigation_in_PlanElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanRoutes_PlanElements_EndPlanElementId",
                table: "PlanRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanRoutes_PlanElements_StartPlanElementId",
                table: "PlanRoutes");

            migrationBuilder.DropIndex(
                name: "IX_PlanRoutes_EndPlanElementId",
                table: "PlanRoutes");

            migrationBuilder.DropIndex(
                name: "IX_PlanRoutes_StartPlanElementId",
                table: "PlanRoutes");

            migrationBuilder.DropColumn(
                name: "EndPlanElementId",
                table: "PlanRoutes");

            migrationBuilder.DropColumn(
                name: "StartPlanElementId",
                table: "PlanRoutes");

            migrationBuilder.AddColumn<int>(
                name: "EndingRouteId",
                table: "PlanElements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartingRouteId",
                table: "PlanElements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanElements_EndingRouteId",
                table: "PlanElements",
                column: "EndingRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanElements_StartingRouteId",
                table: "PlanElements",
                column: "StartingRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanElements_PlanRoutes_EndingRouteId",
                table: "PlanElements",
                column: "EndingRouteId",
                principalTable: "PlanRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanElements_PlanRoutes_StartingRouteId",
                table: "PlanElements",
                column: "StartingRouteId",
                principalTable: "PlanRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanElements_PlanRoutes_EndingRouteId",
                table: "PlanElements");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanElements_PlanRoutes_StartingRouteId",
                table: "PlanElements");

            migrationBuilder.DropIndex(
                name: "IX_PlanElements_EndingRouteId",
                table: "PlanElements");

            migrationBuilder.DropIndex(
                name: "IX_PlanElements_StartingRouteId",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "EndingRouteId",
                table: "PlanElements");

            migrationBuilder.DropColumn(
                name: "StartingRouteId",
                table: "PlanElements");

            migrationBuilder.AddColumn<int>(
                name: "EndPlanElementId",
                table: "PlanRoutes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartPlanElementId",
                table: "PlanRoutes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanRoutes_EndPlanElementId",
                table: "PlanRoutes",
                column: "EndPlanElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanRoutes_StartPlanElementId",
                table: "PlanRoutes",
                column: "StartPlanElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanRoutes_PlanElements_EndPlanElementId",
                table: "PlanRoutes",
                column: "EndPlanElementId",
                principalTable: "PlanElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanRoutes_PlanElements_StartPlanElementId",
                table: "PlanRoutes",
                column: "StartPlanElementId",
                principalTable: "PlanElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
