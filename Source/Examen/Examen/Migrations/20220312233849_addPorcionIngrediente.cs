using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Migrations
{
    public partial class addPorcionIngrediente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Porcion",
                table: "Ingredientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Porcion",
                table: "Ingredientes");
        }
    }
}
