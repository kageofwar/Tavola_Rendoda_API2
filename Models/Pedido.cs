using System.ComponentModel.DataAnnotations;

namespace Tavola_api_2.Models
{
    public class Pedido
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Forma_Pagamento { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Status_Pedido { get; set; }

        [Required]
        public int Total { get; set; }

        public List<PedidoItens> Itens { get; set; }
    }
}