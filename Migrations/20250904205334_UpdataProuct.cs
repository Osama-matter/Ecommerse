using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse.Migrations
{
    /// <inheritdoc />
    public partial class UpdataProuct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_catagouries_catagouryID",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "catagouryID",
                table: "products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_catagouryID",
                table: "products",
                newName: "IX_products_CategoryId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "products",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_products_catagouries_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "catagouries",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_catagouries_CategoryId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "products",
                newName: "catagouryID");

            migrationBuilder.RenameIndex(
                name: "IX_products_CategoryId",
                table: "products",
                newName: "IX_products_catagouryID");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "products",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_products_catagouries_catagouryID",
                table: "products",
                column: "catagouryID",
                principalTable: "catagouries",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
