using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParyanPerfume.Migrations
{
    /// <inheritdoc />
    public partial class EditNameOfTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfume");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    PerfumeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    PerfumeName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: false),
                    PerfumeBrand = table.Column<string>(type: "TEXT", nullable: false),
                    PerfumeSex = table.Column<string>(type: "TEXT", nullable: false),
                    PricePerKilogram = table.Column<int>(type: "INTEGER", nullable: false),
                    PricePer100gram = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: false),
                    ShowInSlider = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.PerfumeId);
                    table.ForeignKey(
                        name: "FK_product_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                table: "product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.CreateTable(
                name: "perfume",
                columns: table => new
                {
                    PerfumeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PerfumeBrand = table.Column<string>(type: "TEXT", nullable: false),
                    PerfumeName = table.Column<string>(type: "TEXT", nullable: false),
                    PerfumeSex = table.Column<string>(type: "TEXT", nullable: false),
                    PricePer100gram = table.Column<int>(type: "INTEGER", nullable: false),
                    PricePerKilogram = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ShowInSlider = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfume", x => x.PerfumeId);
                    table.ForeignKey(
                        name: "FK_perfume_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_perfume_CategoryId",
                table: "perfume",
                column: "CategoryId");
        }
    }
}
