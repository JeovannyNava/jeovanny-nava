using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Migrations
{
    public partial class nuevoDiseñoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Recetas_IdReceta",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_IdReceta",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "IdReceta",
                table: "Ingredientes");

            migrationBuilder.AddColumn<int>(
                name: "RecetaIdReceta",
                table: "Ingredientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_RecetaIdReceta",
                table: "Ingredientes",
                column: "RecetaIdReceta");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Recetas_RecetaIdReceta",
                table: "Ingredientes",
                column: "RecetaIdReceta",
                principalTable: "Recetas",
                principalColumn: "IdReceta",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Recetas_RecetaIdReceta",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_RecetaIdReceta",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "RecetaIdReceta",
                table: "Ingredientes");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Ingredientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdReceta",
                table: "Ingredientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_IdReceta",
                table: "Ingredientes",
                column: "IdReceta");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Recetas_IdReceta",
                table: "Ingredientes",
                column: "IdReceta",
                principalTable: "Recetas",
                principalColumn: "IdReceta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
