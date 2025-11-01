using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParyanPerfume.Migrations
{
    /// <inheritdoc />
    public partial class ProductInitials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfume");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "category",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductNickName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ProductBrand = table.Column<string>(type: "TEXT", nullable: false),
                    ProductSex = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    PricePer100gram = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true),
                    ShowInSlider = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ProductId);
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

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "category",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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
