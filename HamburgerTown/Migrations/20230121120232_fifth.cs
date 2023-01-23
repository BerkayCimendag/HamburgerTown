using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerTown.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SizePrice",
                table: "Sizes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizePrice",
                table: "Sizes");
        }
    }
}
