using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParyanPerfume.Migrations
{
    /// <inheritdoc />
    public partial class EditCategoriesDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryNickName",
                table: "category",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryNickName",
                table: "category");
        }
    }
}
