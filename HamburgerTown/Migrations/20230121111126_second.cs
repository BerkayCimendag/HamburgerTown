using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerTown.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Hamburgers",
                newName: "HamburgerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HamburgerName",
                table: "Hamburgers",
                newName: "Name");
        }
    }
}
