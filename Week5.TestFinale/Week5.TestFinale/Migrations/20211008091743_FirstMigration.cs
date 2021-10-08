using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week5.TestFinale.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Utente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Approvato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spesa", x => x.Id);
                    table.CheckConstraint("CK_Spesa_Importo", "Importo >= 0");
                    table.ForeignKey(
                        name: "FK_Spesa_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spesa_CategoriaId",
                table: "Spesa",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spesa");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
