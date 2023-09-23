using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoWebAhoraSi.Migrations
{
    public partial class TareaPractica3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaDeContratacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Sueldo",
                columns: table => new
                {
                    SueldoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescuentoIV = table.Column<int>(type: "int", nullable: false),
                    Bono = table.Column<int>(type: "int", nullable: false),
                    DescuentoSeguro = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sueldo", x => x.SueldoID);
                    table.ForeignKey(
                        name: "FK_Sueldo_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_de_Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo_de_Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SueldoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoId);
                    table.ForeignKey(
                        name: "FK_Cargo_Sueldo_SueldoID",
                        column: x => x.SueldoID,
                        principalTable: "Sueldo",
                        principalColumn: "SueldoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_SueldoID",
                table: "Cargo",
                column: "SueldoID");

            migrationBuilder.CreateIndex(
                name: "IX_Sueldo_EmpleadoId",
                table: "Sueldo",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Sueldo");

            migrationBuilder.DropTable(
                name: "Empleado");
        }
    }
}
