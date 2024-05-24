using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantApp.Migrations
{
    /// <inheritdoc />
    public partial class latestmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "MenuItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MenuItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CustomerId",
                table: "MenuItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_OrderId",
                table: "MenuItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Customers_CustomerId",
                table: "MenuItems",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Orders_OrderId",
                table: "MenuItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Customers_CustomerId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Orders_OrderId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CustomerId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_OrderId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MenuItems");
        }
    }
}
