using System.ComponentModel.DataAnnotations;
using Tavola_api_2.Models;

namespace Tavola_api_2.Data.Dtos;
public class CreatePedidoItensDto
{
    [Required(ErrorMessage = "O id do pedido deve ser informado!")]
    public int PedidoId { get; set; }

    [Required(ErrorMessage = "O id do produto deve ser informado!")]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "Voce deve inserir a quantidade de itens!")]
    public int Quantidade { get; set; }

    public Pedido Pedido { get; set; }
}