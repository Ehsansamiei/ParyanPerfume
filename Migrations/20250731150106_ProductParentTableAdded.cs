using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParyanPerfume.Migrations
{
    /// <inheritdoc />
    public partial class ProductParentTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bottles");

            migrationBuilder.DropTable(
                name: "fixators");

            migrationBuilder.DropTable(
                name: "perfumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pockets",
                table: "pockets");

            migrationBuilder.RenameTable(
                name: "pockets",
                newName: "Products");

            migrationBuilder.AlterColumn<bool>(
                name: "ShowInSlider",
                table: "Products",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityInPackaging",
                table: "Products",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityInCarton",
                table: "Products",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Bottle_QuantityInCarton",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bottle_QuantityInPackaging",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Fixator_ShowInSlider",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlcoholFree",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Perfume_ShowInSlider",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PricePer100gram",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PricePer20Liters",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Products",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "Products",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Bottle_QuantityInCarton",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Bottle_QuantityInPackaging",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fixator_ShowInSlider",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAlcoholFree",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Perfume_ShowInSlider",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PricePer100gram",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PricePer20Liters",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "pockets");

            migrationBuilder.AlterColumn<bool>(
                name: "ShowInSlider",
                table: "pockets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuantityInPackaging",
                table: "pockets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuantityInCarton",
                table: "pockets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_pockets",
                table: "pockets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "bottles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true),
                    Material = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantityInCarton = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantityInPackaging = table.Column<int>(type: "INTEGER", nullable: false),
                    Volume = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bottles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fixators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true),
                    IsAlcoholFree = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    PricePer20Liters = table.Column<int>(type: "INTEGER", nullable: false),
                    ShowInSlider = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fixators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "perfumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    PricePer100gram = table.Column<int>(type: "INTEGER", nullable: false),
                    ShowInSlider = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfumes", x => x.Id);
                });
        }
    }
}
