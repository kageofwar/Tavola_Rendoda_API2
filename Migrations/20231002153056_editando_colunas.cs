using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tavola_api_2.Migrations
{
    /// <inheritdoc />
    public partial class editando_colunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status_Pedido",
                table: "Pedido",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Forma_Pagamento",
                table: "Pedido",
                newName: "Pagamento");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Pedido",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Pedido",
                newName: "Status_Pedido");

            migrationBuilder.RenameColumn(
                name: "Pagamento",
                table: "Pedido",
                newName: "Forma_Pagamento");

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Pedido",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }
    }
}
