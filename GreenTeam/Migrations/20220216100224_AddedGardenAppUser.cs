using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.Migrations
{
    public partial class AddedGardenAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GardenUser_UserId",
                table: "GardenUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GardenUser_AspNetUsers_UserId",
                table: "GardenUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardenUser_AspNetUsers_UserId",
                table: "GardenUser");

            migrationBuilder.DropIndex(
                name: "IX_GardenUser_UserId",
                table: "GardenUser");
        }
    }
}
