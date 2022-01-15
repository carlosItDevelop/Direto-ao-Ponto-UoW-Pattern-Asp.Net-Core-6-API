using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooperchip.DiretoAoPonto.Data.Migrations
{
    public partial class UpdDisponibilidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Disponibidade",
                table: "Voo",
                newName: "Disponibilidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Disponibilidade",
                table: "Voo",
                newName: "Disponibidade");
        }
    }
}
