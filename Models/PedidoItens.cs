using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tavola_api_2.Models
{
    public class PedidoItens
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O id do Pedido deve ser informado!")]
        public int pedidoId { get; set; }

        [Required(ErrorMessage = "O id do produto deve ser informado!")]
        public int produtoId { get; set; }

        [Required]
        public int quantidade { get; set; }

        [JsonIgnore]
        public virtual Pedido ?Pedido { get; set; }
        public virtual Produto ?Produto { get; set; }
    }
}