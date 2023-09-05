using System.ComponentModel.DataAnnotations;

namespace Tavola_api_2.Models
{
    public class Produto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto deve ser inserido!")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Valor do produto é obrigatório!")]
        public int Valor { get; set; }
    }
}