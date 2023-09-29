using System.ComponentModel.DataAnnotations;

namespace Tavola_api_2.Data.Dtos;
public class CreatePedidoDto
{
    [Required]
    [MaxLength(255)]
    public string Forma_Pagamento { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Status_Pedido { get; set; }
    
    [Required]
    public int Total { get; set; }
}