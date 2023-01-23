using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerTown.Migrations
{
    public partial class eleventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Beverages_SelectedBeverageId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Hamburgers_SelectedHamburgerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SelectedBeverageId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SelectedHamburgerId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "BeverageNameId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HamburgerNameId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BeverageNameId",
                table: "Orders",
                column: "BeverageNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_HamburgerNameId",
                table: "Orders",
                column: "HamburgerNameId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Beverages_BeverageNameId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Hamburgers_HamburgerNameId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BeverageNameId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_HamburgerNameId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BeverageNameId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "HamburgerNameId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SelectedBeverageId",
                table: "Orders",
                column: "SelectedBeverageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SelectedHamburgerId",
                table: "Orders",
                column: "SelectedHamburgerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Beverages_SelectedBeverageId",
                table: "Orders",
                column: "SelectedBeverageId",
                principalTable: "Beverages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Hamburgers_SelectedHamburgerId",
                table: "Orders",
                column: "SelectedHamburgerId",
                principalTable: "Hamburgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
