using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerTown.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraSupplies_Orders_OrderId",
                table: "ExtraSupplies");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ExtraSupplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraSupplies_Orders_OrderId",
                table: "ExtraSupplies",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraSupplies_Orders_OrderId",
                table: "ExtraSupplies");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ExtraSupplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraSupplies_Orders_OrderId",
                table: "ExtraSupplies",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
