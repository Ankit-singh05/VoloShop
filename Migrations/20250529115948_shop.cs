using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoloShop.Migrations
{
    /// <inheritdoc />
    public partial class shop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopProducts_Shopkeepers_ShopkeeperShopId",
                table: "ShopProducts");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "ShopProducts");

            migrationBuilder.DropColumn(
                name: "ShopkeeperName",
                table: "Shopkeepers");

            migrationBuilder.AlterColumn<int>(
                name: "ShopkeeperShopId",
                table: "ShopProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShopkeeperShopId",
                table: "ShopCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopCategories_ShopkeeperShopId",
                table: "ShopCategories",
                column: "ShopkeeperShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCategories_Shopkeepers_ShopkeeperShopId",
                table: "ShopCategories",
                column: "ShopkeeperShopId",
                principalTable: "Shopkeepers",
                principalColumn: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProducts_Shopkeepers_ShopkeeperShopId",
                table: "ShopProducts",
                column: "ShopkeeperShopId",
                principalTable: "Shopkeepers",
                principalColumn: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCategories_Shopkeepers_ShopkeeperShopId",
                table: "ShopCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProducts_Shopkeepers_ShopkeeperShopId",
                table: "ShopProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShopCategories_ShopkeeperShopId",
                table: "ShopCategories");

            migrationBuilder.DropColumn(
                name: "ShopkeeperShopId",
                table: "ShopCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ShopkeeperShopId",
                table: "ShopProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "ShopProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShopkeeperName",
                table: "Shopkeepers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProducts_Shopkeepers_ShopkeeperShopId",
                table: "ShopProducts",
                column: "ShopkeeperShopId",
                principalTable: "Shopkeepers",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
