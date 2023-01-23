using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerTown.Migrations
{
    public partial class asfmas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sizes_SizeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SelectedBeverageId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SelectedHamburgerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Orders",
                newName: "SizeNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SizeId",
                table: "Orders",
                newName: "IX_Orders_SizeNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sizes_SizeNameId",
                table: "Orders",
                column: "SizeNameId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sizes_SizeNameId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "SizeNameId",
                table: "Orders",
                newName: "SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SizeNameId",
                table: "Orders",
                newName: "IX_Orders_SizeId");

            migrationBuilder.AddColumn<int>(
                name: "SelectedBeverageId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedHamburgerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sizes_SizeId",
                table: "Orders",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
