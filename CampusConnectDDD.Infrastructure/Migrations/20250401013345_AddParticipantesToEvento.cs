using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusConnectDDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParticipantesToEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EventoId",
                table: "Usuarios",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Eventos_EventoId",
                table: "Usuarios",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Eventos_EventoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EventoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Usuarios");
        }
    }
}
