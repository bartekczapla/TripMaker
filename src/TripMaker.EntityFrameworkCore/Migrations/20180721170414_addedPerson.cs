using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripMaker.Migrations
{
    public partial class addedPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedPersonId",
                table: "AppTasks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPerson", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_AssignedPersonId",
                table: "AppTasks",
                column: "AssignedPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_AppPerson_AssignedPersonId",
                table: "AppTasks",
                column: "AssignedPersonId",
                principalTable: "AppPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_AppPerson_AssignedPersonId",
                table: "AppTasks");

            migrationBuilder.DropTable(
                name: "AppPerson");

            migrationBuilder.DropIndex(
                name: "IX_AppTasks_AssignedPersonId",
                table: "AppTasks");

            migrationBuilder.DropColumn(
                name: "AssignedPersonId",
                table: "AppTasks");
        }
    }
}
