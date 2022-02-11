using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.Migrations
{
    public partial class PatchNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatchName",
                table: "Patch",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatchName",
                table: "Patch");
        }
    }
}
