using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinances.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjustsInCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RevenueCategorys",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ExpenditureCategory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RevenueCategorys_UserId",
                table: "RevenueCategorys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenditureCategory_UserId",
                table: "ExpenditureCategory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureCategory_Users_UserId",
                table: "ExpenditureCategory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RevenueCategorys_Users_UserId",
                table: "RevenueCategorys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureCategory_Users_UserId",
                table: "ExpenditureCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_RevenueCategorys_Users_UserId",
                table: "RevenueCategorys");

            migrationBuilder.DropIndex(
                name: "IX_RevenueCategorys_UserId",
                table: "RevenueCategorys");

            migrationBuilder.DropIndex(
                name: "IX_ExpenditureCategory_UserId",
                table: "ExpenditureCategory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RevenueCategorys");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExpenditureCategory");
        }
    }
}
