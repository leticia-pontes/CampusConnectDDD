using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusConnectDDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeguidoresAndSeguindoListTypesToIntList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioUsuario");

            migrationBuilder.AlterColumn<string>(
                name: "Curso",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Seguidores",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seguindo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seguidores",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Seguindo",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Curso",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UsuarioUsuario",
                columns: table => new
                {
                    SeguidoresId = table.Column<int>(type: "int", nullable: false),
                    SeguindoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioUsuario", x => new { x.SeguidoresId, x.SeguindoId });
                    table.ForeignKey(
                        name: "FK_UsuarioUsuario_Usuarios_SeguidoresId",
                        column: x => x.SeguidoresId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioUsuario_Usuarios_SeguindoId",
                        column: x => x.SeguindoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUsuario_SeguindoId",
                table: "UsuarioUsuario",
                column: "SeguindoId");
        }
    }
}
