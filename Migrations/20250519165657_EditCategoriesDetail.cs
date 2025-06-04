using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParyanPerfume.Migrations
{
    /// <inheritdoc />
    public partial class EditCategoriesDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryDescription",
                table: "category",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "category",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryDescription",
                table: "category");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "category");
        }
    }
}
