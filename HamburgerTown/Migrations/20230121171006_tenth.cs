using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerTown.Migrations
{
    public partial class tenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Beverages_SelectedBeverageId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedBeverageId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Beverages_SelectedBeverageId",
                table: "Orders",
                column: "SelectedBeverageId",
                principalTable: "Beverages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Beverages_SelectedBeverageId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedBeverageId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Beverages_SelectedBeverageId",
                table: "Orders",
                column: "SelectedBeverageId",
                principalTable: "Beverages",
                principalColumn: "Id");
        }
    }
}
