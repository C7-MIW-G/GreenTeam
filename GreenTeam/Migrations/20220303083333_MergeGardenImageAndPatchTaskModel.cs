using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.Migrations
{
    public partial class MergeGardenImageAndPatchTaskModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "PatchTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatchId = table.Column<int>(type: "int", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatchTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatchTask_Patch_PatchId",
                        column: x => x.PatchId,
                        principalTable: "Patch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garden_GardenImageId",
                table: "Garden",
                column: "GardenImageId");

            migrationBuilder.CreateIndex(
                name: "IX_PatchTask_PatchId",
                table: "PatchTask",
                column: "PatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garden_GardenImage_GardenImageId",
                table: "Garden",
                column: "GardenImageId",
                principalTable: "GardenImage",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garden_GardenImage_GardenImageId",
                table: "Garden");

            migrationBuilder.DropTable(
                name: "GardenImage");

            migrationBuilder.DropTable(
                name: "PatchTask");

            migrationBuilder.DropIndex(
                name: "IX_Garden_GardenImageId",
                table: "Garden");

            migrationBuilder.DropColumn(
                name: "GardenImageId",
                table: "Garden");
        }
    }
}
