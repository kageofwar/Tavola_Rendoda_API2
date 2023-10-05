using Tavola_api_2.Models;
namespace Tavola_api_2.Dtos
{
    public class ReadPedidoItensDto
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public virtual Produto ?Produto { get; set; }
    }
}