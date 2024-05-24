using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantApp.Migrations
{
    /// <inheritdoc />
    public partial class Latest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Customers_CustomerId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CustomerId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "MenuItems");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Staffs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressCity = table.Column<string>(type: "TEXT", nullable: true),
                    AddressCountry = table.Column<string>(type: "TEXT", nullable: true),
                    AddressCounty = table.Column<string>(type: "TEXT", nullable: true),
                    AddressStreet = table.Column<string>(type: "TEXT", nullable: true),
                    AddressZipCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_AddressId",
                table: "Staffs",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Address_AddressId",
                table: "Staffs",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Address_AddressId",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_AddressId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "MenuItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CustomerId",
                table: "MenuItems",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Customers_CustomerId",
                table: "MenuItems",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }
    }
}
