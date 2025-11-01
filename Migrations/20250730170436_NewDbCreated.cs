using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParyanPerfume.Migrations
{
    /// <inheritdoc />
    public partial class NewDbCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bottles_categories_CategoryId",
                table: "bottles");

            migrationBuilder.DropForeignKey(
                name: "FK_fixators_categories_CategoryId",
                table: "fixators");

            migrationBuilder.DropForeignKey(
                name: "FK_perfumes_categories_CategoryId",
                table: "perfumes");

            migrationBuilder.DropForeignKey(
                name: "FK_pockets_categories_CategoryId",
                table: "pockets");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_pockets_CategoryId",
                table: "pockets");

            migrationBuilder.DropIndex(
                name: "IX_perfumes_CategoryId",
                table: "perfumes");

            migrationBuilder.DropIndex(
                name: "IX_fixators_CategoryId",
                table: "fixators");

            migrationBuilder.DropIndex(
                name: "IX_bottles_CategoryId",
                table: "bottles");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "perfumes");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "pockets",
                newName: "QuantityInPackaging");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "fixators",
                newName: "PricePer20Liters");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "bottles",
                newName: "QuantityInPackaging");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "pockets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityInCarton",
                table: "pockets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlcoholFree",
                table: "fixators",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "fixators",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "bottles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "bottles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "bottles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuantityInCarton",
                table: "bottles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "pockets");

            migrationBuilder.DropColumn(
                name: "QuantityInCarton",
                table: "pockets");

            migrationBuilder.DropColumn(
                name: "IsAlcoholFree",
                table: "fixators");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "fixators");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "bottles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "bottles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "bottles");

            migrationBuilder.DropColumn(
                name: "QuantityInCarton",
                table: "bottles");

            migrationBuilder.RenameColumn(
                name: "QuantityInPackaging",
                table: "pockets",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "PricePer20Liters",
                table: "fixators",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "QuantityInPackaging",
                table: "bottles",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "perfumes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pockets_CategoryId",
                table: "pockets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_perfumes_CategoryId",
                table: "perfumes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_fixators_CategoryId",
                table: "fixators",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_bottles_CategoryId",
                table: "bottles",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_bottles_categories_CategoryId",
                table: "bottles",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fixators_categories_CategoryId",
                table: "fixators",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_perfumes_categories_CategoryId",
                table: "perfumes",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pockets_categories_CategoryId",
                table: "pockets",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
