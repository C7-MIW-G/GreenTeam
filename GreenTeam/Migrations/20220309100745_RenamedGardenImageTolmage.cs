using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.Migrations
{
    public partial class RenamedGardenImageTolmage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garden_GardenImage_GardenImageId",
                table: "Garden");

            migrationBuilder.DropTable(
                name: "GardenImage");

            migrationBuilder.RenameColumn(
                name: "GardenImageId",
                table: "Garden",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Garden_GardenImageId",
                table: "Garden",
                newName: "IX_Garden_ImageId");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Garden_Image_ImageId",
                table: "Garden",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garden_Image_ImageId",
                table: "Garden");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Garden",
                newName: "GardenImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Garden_ImageId",
                table: "Garden",
                newName: "IX_Garden_GardenImageId");

            migrationBuilder.CreateTable(
                name: "GardenImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenImage", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Garden_GardenImage_GardenImageId",
                table: "Garden",
                column: "GardenImageId",
                principalTable: "GardenImage",
                principalColumn: "Id");
        }
    }
}
