using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSLGaming.Data.Migrations
{
    /// <inheritdoc />
    public partial class agerestricionadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Categories_CategoryId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Product_ProductId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_GenereProducts_Product_ProductId",
                table: "GenereProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AgeRestriction_AgeRestrictionId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryProduct",
                table: "CategoryProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgeRestriction",
                table: "AgeRestriction");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "CategoryProduct",
                newName: "CategoryProducts");

            migrationBuilder.RenameTable(
                name: "AgeRestriction",
                newName: "AgeRestrictions");

            migrationBuilder.RenameIndex(
                name: "IX_Product_AgeRestrictionId",
                table: "Products",
                newName: "IX_Products_AgeRestrictionId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProduct_ProductId",
                table: "CategoryProducts",
                newName: "IX_CategoryProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryProducts",
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeRestrictions",
                table: "AgeRestrictions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducts_Categories_CategoryId",
                table: "CategoryProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducts_Products_ProductId",
                table: "CategoryProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenereProducts_Products_ProductId",
                table: "GenereProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AgeRestrictions_AgeRestrictionId",
                table: "Products",
                column: "AgeRestrictionId",
                principalTable: "AgeRestrictions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducts_Categories_CategoryId",
                table: "CategoryProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducts_Products_ProductId",
                table: "CategoryProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GenereProducts_Products_ProductId",
                table: "GenereProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AgeRestrictions_AgeRestrictionId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryProducts",
                table: "CategoryProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgeRestrictions",
                table: "AgeRestrictions");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "CategoryProducts",
                newName: "CategoryProduct");

            migrationBuilder.RenameTable(
                name: "AgeRestrictions",
                newName: "AgeRestriction");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AgeRestrictionId",
                table: "Product",
                newName: "IX_Product_AgeRestrictionId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProducts_ProductId",
                table: "CategoryProduct",
                newName: "IX_CategoryProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryProduct",
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeRestriction",
                table: "AgeRestriction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Categories_CategoryId",
                table: "CategoryProduct",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Product_ProductId",
                table: "CategoryProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenereProducts_Product_ProductId",
                table: "GenereProducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AgeRestriction_AgeRestrictionId",
                table: "Product",
                column: "AgeRestrictionId",
                principalTable: "AgeRestriction",
                principalColumn: "Id");
        }
    }
}
