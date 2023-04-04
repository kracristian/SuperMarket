using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarket.Data.Migrations
{
    /// <inheritdoc />
    public partial class ELiminarColumnaErronea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permiso_Usuario_UsuarioIdUsuario",
                table: "Permiso");

            migrationBuilder.DropIndex(
                name: "IX_Permiso_UsuarioIdUsuario",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Permiso");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Permiso",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_IdUsuario",
                table: "Permiso",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Permiso_Usuario_IdUsuario",
                table: "Permiso",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permiso_Usuario_IdUsuario",
                table: "Permiso");

            migrationBuilder.DropIndex(
                name: "IX_Permiso_IdUsuario",
                table: "Permiso");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Permiso",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Permiso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_UsuarioIdUsuario",
                table: "Permiso",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Permiso_Usuario_UsuarioIdUsuario",
                table: "Permiso",
                column: "UsuarioIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
