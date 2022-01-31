using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.Migrations
{
    public partial class removedSizeInSqm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeInSqm",
                table: "Garden");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeInSqm",
                table: "Garden",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
