using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusConnectDDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterComentarioTypeToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Postagens SET Comentarios = CAST(Comentarios AS NVARCHAR(MAX))");
            
            migrationBuilder.AlterColumn<string>(
                name: "Comentarios",
                table: "Postagens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Comentarios",
                table: "Postagens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
