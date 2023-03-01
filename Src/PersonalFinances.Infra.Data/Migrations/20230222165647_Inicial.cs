using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinances.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureCategory_Users_UserId",
                table: "ExpenditureCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_ExpenditureCategory_ExpenditureCategoryId",
                table: "Expenditures");

            migrationBuilder.DropForeignKey(
                name: "FK_RevenueCategorys_Users_UserId",
                table: "RevenueCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_RevenueCategorys_RevenueCategoryId",
                table: "Revenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RevenueCategorys",
                table: "RevenueCategorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenditureCategory",
                table: "ExpenditureCategory");

            migrationBuilder.RenameTable(
                name: "RevenueCategorys",
                newName: "RevenueCategories");

            migrationBuilder.RenameTable(
                name: "ExpenditureCategory",
                newName: "ExpenditureCategories");

            migrationBuilder.RenameIndex(
                name: "IX_RevenueCategorys_UserId",
                table: "RevenueCategories",
                newName: "IX_RevenueCategories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenditureCategory_UserId",
                table: "ExpenditureCategories",
                newName: "IX_ExpenditureCategories_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RevenueCategories",
                table: "RevenueCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenditureCategories",
                table: "ExpenditureCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureCategories_Users_UserId",
                table: "ExpenditureCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_ExpenditureCategories_ExpenditureCategoryId",
                table: "Expenditures",
                column: "ExpenditureCategoryId",
                principalTable: "ExpenditureCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RevenueCategories_Users_UserId",
                table: "RevenueCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_RevenueCategories_RevenueCategoryId",
                table: "Revenues",
                column: "RevenueCategoryId",
                principalTable: "RevenueCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureCategories_Users_UserId",
                table: "ExpenditureCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_ExpenditureCategories_ExpenditureCategoryId",
                table: "Expenditures");

            migrationBuilder.DropForeignKey(
                name: "FK_RevenueCategories_Users_UserId",
                table: "RevenueCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_RevenueCategories_RevenueCategoryId",
                table: "Revenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RevenueCategories",
                table: "RevenueCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenditureCategories",
                table: "ExpenditureCategories");

            migrationBuilder.RenameTable(
                name: "RevenueCategories",
                newName: "RevenueCategorys");

            migrationBuilder.RenameTable(
                name: "ExpenditureCategories",
                newName: "ExpenditureCategory");

            migrationBuilder.RenameIndex(
                name: "IX_RevenueCategories_UserId",
                table: "RevenueCategorys",
                newName: "IX_RevenueCategorys_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenditureCategories_UserId",
                table: "ExpenditureCategory",
                newName: "IX_ExpenditureCategory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RevenueCategorys",
                table: "RevenueCategorys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenditureCategory",
                table: "ExpenditureCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureCategory_Users_UserId",
                table: "ExpenditureCategory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_ExpenditureCategory_ExpenditureCategoryId",
                table: "Expenditures",
                column: "ExpenditureCategoryId",
                principalTable: "ExpenditureCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RevenueCategorys_Users_UserId",
                table: "RevenueCategorys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_RevenueCategorys_RevenueCategoryId",
                table: "Revenues",
                column: "RevenueCategoryId",
                principalTable: "RevenueCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
