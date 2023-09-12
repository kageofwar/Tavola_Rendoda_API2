using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tavola_api_2.Migrations
{
    /// <inheritdoc />
    public partial class editando_campos_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Categoria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_ProdutoId",
                table: "Categoria",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Produtos_ProdutoId",
                table: "Categoria",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Produtos_ProdutoId",
                table: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_ProdutoId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Categoria");
        }
    }
}
