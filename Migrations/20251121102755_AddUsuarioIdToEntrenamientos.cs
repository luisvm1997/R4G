using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R4G.App.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioIdToEntrenamientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Entrenamientos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Entrenamientos");
        }
    }
}
