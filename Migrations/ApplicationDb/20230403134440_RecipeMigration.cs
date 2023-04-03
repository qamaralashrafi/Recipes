using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBook.Migrations.ApplicationDb
{
    public partial class RecipeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllRecipes",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeIngredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeSteps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipeImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllRecipes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllRecipes");
        }
    }
}
