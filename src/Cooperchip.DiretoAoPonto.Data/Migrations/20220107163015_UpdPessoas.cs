using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooperchip.DiretoAoPonto.Data.Migrations
{
    public partial class UpdPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Voo_VooId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.RenameTable(
                name: "Pessoas",
                newName: "Pessoa");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_VooId",
                table: "Pessoa",
                newName: "IX_Pessoa_VooId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Voo_VooId",
                table: "Pessoa",
                column: "VooId",
                principalTable: "Voo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Voo_VooId",
                table: "Pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "Pessoas");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_VooId",
                table: "Pessoas",
                newName: "IX_Pessoas_VooId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Voo_VooId",
                table: "Pessoas",
                column: "VooId",
                principalTable: "Voo",
                principalColumn: "Id");
        }
    }
}
