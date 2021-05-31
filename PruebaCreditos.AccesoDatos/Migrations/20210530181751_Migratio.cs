using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaCreditos.AccesoDatos.Migrations
{
    public partial class Migratio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credito_AspNetUsers_ClientesId",
                table: "Credito");

            migrationBuilder.AlterColumn<string>(
                name: "ClientesId",
                table: "Credito",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Amortizacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Credito_AspNetUsers_ClientesId",
                table: "Credito",
                column: "ClientesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credito_AspNetUsers_ClientesId",
                table: "Credito");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Amortizacion");

            migrationBuilder.AlterColumn<string>(
                name: "ClientesId",
                table: "Credito",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Credito_AspNetUsers_ClientesId",
                table: "Credito",
                column: "ClientesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
