using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.Migrations
{
    public partial class GardenUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GardenUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GardenId = table.Column<int>(type: "int", nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false),
                    IsMember = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GardenUser_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenUser_Garden_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Garden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenUser_GardenId",
                table: "GardenUser",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_GardenUser_IdentityUserId",
                table: "GardenUser",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenUser");
        }
    }
}
