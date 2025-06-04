using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParyanPerfume.Migrations
{
    /// <inheritdoc />
    public partial class EditNameOfTableToPerfume2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "perfume",
                newName: "PerfumeName");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "perfume",
                newName: "PerfumeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerfumeName",
                table: "perfume",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "PerfumeId",
                table: "perfume",
                newName: "ProductId");
        }
    }
}
