using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patch_Garden_GardenId",
                table: "Patch");

            migrationBuilder.AlterColumn<int>(
                name: "GardenId",
                table: "Patch",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patch_Garden_GardenId",
                table: "Patch",
                column: "GardenId",
                principalTable: "Garden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patch_Garden_GardenId",
                table: "Patch");

            migrationBuilder.AlterColumn<int>(
                name: "GardenId",
                table: "Patch",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Patch_Garden_GardenId",
                table: "Patch",
                column: "GardenId",
                principalTable: "Garden",
                principalColumn: "Id");
        }
    }
}
