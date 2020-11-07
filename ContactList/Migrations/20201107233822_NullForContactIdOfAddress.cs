using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactListApi.Migrations
{
    public partial class NullForContactIdOfAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_ContactId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContactId",
                table: "Addresses",
                column: "ContactId",
                unique: true,
                filter: "[ContactId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_ContactId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContactId",
                table: "Addresses",
                column: "ContactId",
                unique: true);
        }
    }
}
