using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusConnectDDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEventoAbertoToEventoAndCurtidasComentariosToPostagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Comentarios",
                table: "Postagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Curtidas",
                table: "Postagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EventoAberto",
                table: "Eventos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Postagens");

            migrationBuilder.DropColumn(
                name: "Curtidas",
                table: "Postagens");

            migrationBuilder.DropColumn(
                name: "EventoAberto",
                table: "Eventos");
        }
    }
}
