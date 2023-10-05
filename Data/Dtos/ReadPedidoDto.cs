using System.ComponentModel.DataAnnotations.Schema;
using Tavola_api_2.Models;

namespace Tavola_api_2.Dtos
{
    public class ReadPedidoDto
    {
        public int Id { get; set; }
        public string pagamento { get; set; }
        public string status { get; set; }
        public decimal total { get; set; }
        public List<PedidoItens> itens { get; set; }
    }
}