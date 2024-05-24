using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuItemName",
                table: "MenuItems",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "Allergens",
                table: "MenuItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "MenuItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "MenuItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MenuItems",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allergens",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Availability",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "MenuItems",
                newName: "MenuItemName");
        }
    }
}
