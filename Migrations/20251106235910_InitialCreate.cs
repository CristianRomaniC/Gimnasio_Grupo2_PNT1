using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GimnasioGrupo2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gimnasios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gimnasios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposMembresia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMembresia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposRutina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRutina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    MembresiaVigente = table.Column<bool>(type: "bit", nullable: false),
                    Objetivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GimnasioId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Dni);
                    table.ForeignKey(
                        name: "FK_Clientes_Gimnasios_GimnasioId",
                        column: x => x.GimnasioId,
                        principalTable: "Gimnasios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ClienteMembresias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteDni = table.Column<int>(type: "int", nullable: false),
                    TipoMembresiaId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMembresias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteMembresias_Clientes_ClienteDni",
                        column: x => x.ClienteDni,
                        principalTable: "Clientes",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteMembresias_TiposMembresia_TipoMembresiaId",
                        column: x => x.TipoMembresiaId,
                        principalTable: "TiposMembresia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rutinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TiempoEstimado = table.Column<double>(type: "float", nullable: false),
                    CantidadDeEjercicios = table.Column<int>(type: "int", nullable: false),
                    TipoRutinaId = table.Column<int>(type: "int", nullable: false),
                    ClienteDni = table.Column<int>(type: "int", nullable: true),
                    GimnasioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rutinas_Clientes_ClienteDni",
                        column: x => x.ClienteDni,
                        principalTable: "Clientes",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Rutinas_Gimnasios_GimnasioId",
                        column: x => x.GimnasioId,
                        principalTable: "Gimnasios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rutinas_TiposRutina_TipoRutinaId",
                        column: x => x.TipoRutinaId,
                        principalTable: "TiposRutina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMembresias_ClienteDni",
                table: "ClienteMembresias",
                column: "ClienteDni");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMembresias_TipoMembresiaId",
                table: "ClienteMembresias",
                column: "TipoMembresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_GimnasioId",
                table: "Clientes",
                column: "GimnasioId");

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_ClienteDni",
                table: "Rutinas",
                column: "ClienteDni");

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_GimnasioId",
                table: "Rutinas",
                column: "GimnasioId");

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_TipoRutinaId",
                table: "Rutinas",
                column: "TipoRutinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteMembresias");

            migrationBuilder.DropTable(
                name: "Rutinas");

            migrationBuilder.DropTable(
                name: "TiposMembresia");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposRutina");

            migrationBuilder.DropTable(
                name: "Gimnasios");
        }
    }
}
