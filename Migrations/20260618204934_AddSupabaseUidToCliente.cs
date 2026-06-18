using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIProgra2.Migrations
{
    /// <inheritdoc />
    public partial class AddSupabaseUidToCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupabaseUid",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 1,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 2,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 3,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 4,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 5,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 6,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 7,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 8,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 9,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 10,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 11,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 12,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 13,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 14,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 15,
                column: "SupabaseUid",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_SupabaseUid",
                table: "Clientes",
                column: "SupabaseUid",
                unique: true,
                filter: "\"SupabaseUid\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_SupabaseUid",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "SupabaseUid",
                table: "Clientes");
        }
    }
}
