using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.Migrations
{
    public partial class AddedGardenImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatchTask_AspNetUsers_AppUserId",
                table: "PatchTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PatchTask_Patch_PatchId",
                table: "PatchTask");

            migrationBuilder.DropIndex(
                name: "IX_PatchTask_AppUserId",
                table: "PatchTask");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "PatchTask");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PatchTask");

            migrationBuilder.DropColumn(
                name: "DateDone",
                table: "PatchTask");

            migrationBuilder.AlterColumn<string>(
                name: "TaskDescription",
                table: "PatchTask",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PatchId",
                table: "PatchTask",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskName",
                table: "PatchTask",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GardenImageId",
                table: "Garden",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GardenImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenImage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garden_GardenImageId",
                table: "Garden",
                column: "GardenImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garden_GardenImage_GardenImageId",
                table: "Garden",
                column: "GardenImageId",
                principalTable: "GardenImage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatchTask_Patch_PatchId",
                table: "PatchTask",
                column: "PatchId",
                principalTable: "Patch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garden_GardenImage_GardenImageId",
                table: "Garden");

            migrationBuilder.DropForeignKey(
                name: "FK_PatchTask_Patch_PatchId",
                table: "PatchTask");

            migrationBuilder.DropTable(
                name: "GardenImage");

            migrationBuilder.DropIndex(
                name: "IX_Garden_GardenImageId",
                table: "Garden");

            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "PatchTask");

            migrationBuilder.DropColumn(
                name: "GardenImageId",
                table: "Garden");

            migrationBuilder.AlterColumn<string>(
                name: "TaskDescription",
                table: "PatchTask",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatchId",
                table: "PatchTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "PatchTask",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "PatchTask",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDone",
                table: "PatchTask",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_PatchTask_AppUserId",
                table: "PatchTask",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatchTask_AspNetUsers_AppUserId",
                table: "PatchTask",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatchTask_Patch_PatchId",
                table: "PatchTask",
                column: "PatchId",
                principalTable: "Patch",
                principalColumn: "Id");
        }
    }
}
