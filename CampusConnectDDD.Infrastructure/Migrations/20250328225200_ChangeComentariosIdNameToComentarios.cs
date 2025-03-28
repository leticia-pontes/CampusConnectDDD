using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusConnectDDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeComentariosIdNameToComentarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Postagens_PostagemId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_PostagemId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "PostagemId",
                table: "Comentarios");

            migrationBuilder.AlterColumn<string>(
                name: "Seguindo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Seguidores",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Postagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Postagens");

            migrationBuilder.AlterColumn<string>(
                name: "Seguindo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Seguidores",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PostagemId",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PostagemId",
                table: "Comentarios",
                column: "PostagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Postagens_PostagemId",
                table: "Comentarios",
                column: "PostagemId",
                principalTable: "Postagens",
                principalColumn: "Id");
        }
    }
}
