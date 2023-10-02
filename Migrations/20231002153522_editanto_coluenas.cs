using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tavola_api_2.Migrations
{
    /// <inheritdoc />
    public partial class editanto_coluenas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Pedido_PedidoId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "PedidoItens",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "PedidoItens",
                newName: "produtoId");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "PedidoItens",
                newName: "pedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItens_ProdutoId",
                table: "PedidoItens",
                newName: "IX_PedidoItens_produtoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItens_PedidoId",
                table: "PedidoItens",
                newName: "IX_PedidoItens_pedidoId");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Pedido",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Pedido",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Pagamento",
                table: "Pedido",
                newName: "pagamento");

            migrationBuilder.AlterColumn<float>(
                name: "total",
                table: "Pedido",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Pedido_pedidoId",
                table: "PedidoItens",
                column: "pedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Produtos_produtoId",
                table: "PedidoItens",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Pedido_pedidoId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Produtos_produtoId",
                table: "PedidoItens");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "PedidoItens",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "produtoId",
                table: "PedidoItens",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "pedidoId",
                table: "PedidoItens",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItens_produtoId",
                table: "PedidoItens",
                newName: "IX_PedidoItens_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItens_pedidoId",
                table: "PedidoItens",
                newName: "IX_PedidoItens_PedidoId");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "Pedido",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Pedido",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "pagamento",
                table: "Pedido",
                newName: "Pagamento");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Pedido",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Pedido_PedidoId",
                table: "PedidoItens",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
