using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusConnectDDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAutorIdTypeToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_Usuarios_AutorId",
                table: "Postagens");

            migrationBuilder.DropIndex(
                name: "IX_Postagens_AutorId",
                table: "Postagens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Postagens_AutorId",
                table: "Postagens",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_Usuarios_AutorId",
                table: "Postagens",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
