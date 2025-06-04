using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoloShop.Migrations
{
    /// <inheritdoc />
    public partial class shop1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCategories_Shopkeepers_ShopkeeperShopId",
                table: "ShopCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProducts_Shopkeepers_ShopkeeperShopId",
                table: "ShopProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShopProducts_ShopkeeperShopId",
                table: "ShopProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShopCategories_ShopkeeperShopId",
                table: "ShopCategories");

            migrationBuilder.DropColumn(
                name: "ShopkeeperShopId",
                table: "ShopProducts");

            migrationBuilder.DropColumn(
                name: "ShopkeeperShopId",
                table: "ShopCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopkeeperShopId",
                table: "ShopProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopkeeperShopId",
                table: "ShopCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopProducts_ShopkeeperShopId",
                table: "ShopProducts",
                column: "ShopkeeperShopId");

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
    }
}
