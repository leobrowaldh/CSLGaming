using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSLGaming.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial1234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AgeRestrictions_AgeRestrictionId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgeRestrictions",
                table: "AgeRestrictions");

            migrationBuilder.RenameTable(
                name: "AgeRestrictions",
                newName: "AgeRestriction");

            migrationBuilder.AlterColumn<int>(
                name: "AgeRestrictionId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AgeRestrictionId1",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeRestriction",
                table: "AgeRestriction",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AgeRestrictionId1",
                table: "Product",
                column: "AgeRestrictionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AgeRestriction_AgeRestrictionId",
                table: "Product",
                column: "AgeRestrictionId",
                principalTable: "AgeRestriction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AgeRestriction_AgeRestrictionId1",
                table: "Product",
                column: "AgeRestrictionId1",
                principalTable: "AgeRestriction",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AgeRestriction_AgeRestrictionId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AgeRestriction_AgeRestrictionId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AgeRestrictionId1",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgeRestriction",
                table: "AgeRestriction");

            migrationBuilder.DropColumn(
                name: "AgeRestrictionId1",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "AgeRestriction",
                newName: "AgeRestrictions");

            migrationBuilder.AlterColumn<int>(
                name: "AgeRestrictionId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeRestrictions",
                table: "AgeRestrictions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AgeRestrictions_AgeRestrictionId",
                table: "Product",
                column: "AgeRestrictionId",
                principalTable: "AgeRestrictions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
