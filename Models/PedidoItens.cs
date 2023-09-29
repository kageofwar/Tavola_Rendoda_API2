using System.ComponentModel.DataAnnotations;

namespace Tavola_api_2.Models
{
    public class PedidoItens
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O id do pedido deve ser informado!")]
        public virtual Pedido Pedido { get; set; }

        [Required(ErrorMessage = "O id do produto deve ser informado!")]
        public virtual Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}