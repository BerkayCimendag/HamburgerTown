using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerTown.Migrations
{
    public partial class olvo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Beverages_BeverageNameId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Hamburgers_HamburgerNameId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sizes_SizeNameId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "SizeNameId",
                table: "Orders",
                newName: "SizesId");

            migrationBuilder.RenameColumn(
                name: "HamburgerNameId",
                table: "Orders",
                newName: "HamburgersId");

            migrationBuilder.RenameColumn(
                name: "BeverageNameId",
                table: "Orders",
                newName: "BeveragesId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SizeNameId",
                table: "Orders",
                newName: "IX_Orders_SizesId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HamburgerNameId",
                table: "Orders",
                newName: "IX_Orders_HamburgersId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BeverageNameId",
                table: "Orders",
                newName: "IX_Orders_BeveragesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Beverages_BeveragesId",
                table: "Orders",
                column: "BeveragesId",
                principalTable: "Beverages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Hamburgers_HamburgersId",
                table: "Orders",
                column: "HamburgersId",
                principalTable: "Hamburgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sizes_SizesId",
                table: "Orders",
                column: "SizesId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Beverages_BeveragesId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Hamburgers_HamburgersId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sizes_SizesId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "SizesId",
                table: "Orders",
                newName: "SizeNameId");

            migrationBuilder.RenameColumn(
                name: "HamburgersId",
                table: "Orders",
                newName: "HamburgerNameId");

            migrationBuilder.RenameColumn(
                name: "BeveragesId",
                table: "Orders",
                newName: "BeverageNameId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SizesId",
                table: "Orders",
                newName: "IX_Orders_SizeNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HamburgersId",
                table: "Orders",
                newName: "IX_Orders_HamburgerNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BeveragesId",
                table: "Orders",
                newName: "IX_Orders_BeverageNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Beverages_BeverageNameId",
                table: "Orders",
                column: "BeverageNameId",
                principalTable: "Beverages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Hamburgers_HamburgerNameId",
                table: "Orders",
                column: "HamburgerNameId",
                principalTable: "Hamburgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sizes_SizeNameId",
                table: "Orders",
                column: "SizeNameId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
