using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GimnasioGrupo2.Migrations
{
    /// <inheritdoc />
    public partial class AddObjetoPerdido_Entregado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjetosPerdidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaEncontrado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClienteDni = table.Column<int>(type: "int", nullable: true),
                    Entregado = table.Column<bool>(type: "bit", nullable: false),
                    FechaEntregado = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosPerdidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjetosPerdidos_Clientes_ClienteDni",
                        column: x => x.ClienteDni,
                        principalTable: "Clientes",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjetosPerdidos_ClienteDni",
                table: "ObjetosPerdidos",
                column: "ClienteDni");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjetosPerdidos");
        }
    }
}
