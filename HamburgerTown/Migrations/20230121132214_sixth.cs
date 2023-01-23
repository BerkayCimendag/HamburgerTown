using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerTown.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hamburgers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hamburgers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
