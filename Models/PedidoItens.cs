using System.ComponentModel.DataAnnotations;

namespace Tavola_api_2.Models
{
    public class PedidoItens
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O id do Pedido deve ser informado!")]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "O id do produto deve ser informado!")]
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public virtual Pedido ?Pedido { get; set; }
        public virtual Produto ?Produto { get; set; }
    }
}