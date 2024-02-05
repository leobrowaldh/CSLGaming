using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSLGaming.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Product");
        }
    }
}
