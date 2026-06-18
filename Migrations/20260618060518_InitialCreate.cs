using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoIProgra2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloqueosMesas",
                columns: table => new
                {
                    BloqueoMesaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MesaId = table.Column<int>(type: "integer", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Detalle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloqueosMesas", x => x.BloqueoMesaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ced = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellidos = table.Column<string>(type: "text", nullable: false),
                    Tel = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDeReservas",
                columns: table => new
                {
                    EstadoDeReservaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDeReservas", x => x.EstadoDeReservaId);
                });

            migrationBuilder.CreateTable(
                name: "ListasDeEspera",
                columns: table => new
                {
                    ListaDeEsperaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    TurnoId = table.Column<int>(type: "integer", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "integer", nullable: false),
                    HoraSolicitud = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasDeEspera", x => x.ListaDeEsperaId);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    MesaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacidad = table.Column<int>(type: "integer", nullable: false),
                    ZonaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.MesaId);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TurnoId = table.Column<int>(type: "integer", nullable: false),
                    EstadoDeReservaId = table.Column<int>(type: "integer", nullable: false),
                    CantidaPersonas = table.Column<int>(type: "integer", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    MesaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    TurnoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoraInicio = table.Column<int>(type: "integer", nullable: false),
                    HoraFin = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.TurnoId);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    ZonaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Seccion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.ZonaId);
                });

            migrationBuilder.InsertData(
                table: "BloqueosMesas",
                columns: new[] { "BloqueoMesaId", "Detalle", "Fecha", "HoraFin", "HoraInicio", "MesaId" },
                values: new object[,]
                {
                    { 1, "Mantenimiento de mesa", new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, "Evento privado", new DateTime(2026, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 3, "Limpieza profunda", new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 4, "Reserva especial", new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, "Inspección de zona VIP", new DateTime(2026, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), 9 }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellidos", "Ced", "Email", "Nombre", "Tel" },
                values: new object[,]
                {
                    { 1, "Pérez López", 101110111, "juan@email.com", "Juan", 88881111 },
                    { 2, "González Mora", 202220222, "maria@email.com", "María", 88882222 },
                    { 3, "Rodríguez Soto", 303330333, "carlos@email.com", "Carlos", 88883333 },
                    { 4, "Martínez Cruz", 404440444, "ana@email.com", "Ana", 88884444 },
                    { 5, "Hernández Vega", 505550555, "luis@email.com", "Luis", 88885555 },
                    { 6, "Ramírez Quirós", 606660666, "sofia@email.com", "Sofía", 88886666 },
                    { 7, "Vargas Jiménez", 707770777, "diego@email.com", "Diego", 88887777 },
                    { 8, "Castro Solano", 808880888, "valeria@email.com", "Valeria", 88888888 },
                    { 9, "Mora Brenes", 909990999, "andres@email.com", "Andrés", 88889999 },
                    { 10, "Rojas Campos", 101010101, "camila@email.com", "Camila", 88880000 },
                    { 11, "Núñez Alfaro", 111111110, "sebastian@email.com", "Sebastián", 87771111 },
                    { 12, "Flores Madrigal", 121212120, "isabella@email.com", "Isabella", 87772222 },
                    { 13, "Chaves Araya", 131313130, "mateo@email.com", "Mateo", 87773333 },
                    { 14, "Segura Monge", 141414140, "daniela@email.com", "Daniela", 87774444 },
                    { 15, "Herrera Vindas", 151515150, "gabriel@email.com", "Gabriel", 87775555 }
                });

            migrationBuilder.InsertData(
                table: "EstadoDeReservas",
                columns: new[] { "EstadoDeReservaId", "Estado" },
                values: new object[,]
                {
                    { 1, "Activa" },
                    { 2, "Cancelada" },
                    { 3, "Atendida" }
                });

            migrationBuilder.InsertData(
                table: "ListasDeEspera",
                columns: new[] { "ListaDeEsperaId", "CantidadPersonas", "ClienteId", "HoraSolicitud", "TurnoId" },
                values: new object[,]
                {
                    { 1, 4, 3, new DateTime(2026, 6, 15, 11, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 2, 4, new DateTime(2026, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 3, 6, new DateTime(2026, 6, 16, 7, 45, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 5, 9, new DateTime(2026, 6, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 2, 12, new DateTime(2026, 6, 18, 17, 30, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "MesaId", "Capacidad", "ZonaId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 1 },
                    { 3, 6, 1 },
                    { 4, 4, 2 },
                    { 5, 2, 2 },
                    { 6, 8, 2 },
                    { 7, 4, 3 },
                    { 8, 6, 3 },
                    { 9, 4, 4 },
                    { 10, 8, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaId", "CantidaPersonas", "ClienteId", "EstadoDeReservaId", "Fecha", "HoraFin", "HoraInicio", "MesaId", "TurnoId" },
                values: new object[,]
                {
                    { 1, 3, 1, 1, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 2, 2, 2, 1, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 3, 4, 3, 1, new DateTime(2026, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 4, 5, 4, 1, new DateTime(2026, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 16, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 5, 2, 5, 1, new DateTime(2026, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), 5, 3 },
                    { 6, 6, 6, 1, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 7, 4, 7, 1, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 8, 7, 8, 1, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 9, 4, 9, 1, new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 10, 2, 10, 2, new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 11, 3, 11, 1, new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 12, 4, 12, 1, new DateTime(2026, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 19, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 13, 3, 13, 3, new DateTime(2026, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 19, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 19, 18, 0, 0, 0, DateTimeKind.Unspecified), 7, 3 },
                    { 14, 6, 14, 1, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 15, 2, 15, 1, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 16, 4, 15, 1, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 20, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), 9, 3 }
                });

            migrationBuilder.InsertData(
                table: "Turnos",
                columns: new[] { "TurnoId", "HoraFin", "HoraInicio" },
                values: new object[,]
                {
                    { 1, 11, 8 },
                    { 2, 17, 12 },
                    { 3, 22, 18 }
                });

            migrationBuilder.InsertData(
                table: "Zonas",
                columns: new[] { "ZonaId", "Seccion" },
                values: new object[,]
                {
                    { 1, "Interior" },
                    { 2, "Terraza" },
                    { 3, "Jardín" },
                    { 4, "VIP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloqueosMesas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadoDeReservas");

            migrationBuilder.DropTable(
                name: "ListasDeEspera");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Zonas");
        }
    }
}
