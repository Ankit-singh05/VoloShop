using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoloShop.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductOrders_ProductOrderOrderId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductOrderOrderId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductOrderOrderId",
                table: "OrderDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductOrderOrderId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductOrderOrderId",
                table: "OrderDetails",
                column: "ProductOrderOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductOrders_ProductOrderOrderId",
                table: "OrderDetails",
                column: "ProductOrderOrderId",
                principalTable: "ProductOrders",
                principalColumn: "OrderId");
        }
    }
}
