using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tavola_api_2.Models
{
    public class Pedido
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string pagamento { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string status { get; set; }

        [Required]
        [Precision(8,2)]
        public decimal total { get; set; }

        public List<PedidoItens> itens { get; set; }
    }
}