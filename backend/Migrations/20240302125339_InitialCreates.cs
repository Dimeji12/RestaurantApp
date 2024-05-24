using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Staffs_StaffId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Staffs_StaffId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Staffs_StaffId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StaffId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StaffId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_StaffId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Staffs",
                newName: "StaffEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffEmail",
                table: "Staffs",
                newName: "Role");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Reservations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "MenuItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StaffId",
                table: "Reservations",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StaffId",
                table: "Orders",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_StaffId",
                table: "MenuItems",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Staffs_StaffId",
                table: "MenuItems",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Staffs_StaffId",
                table: "Orders",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Staffs_StaffId",
                table: "Reservations",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId");
        }
    }
}
