using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Tavola_api_2.Models
{
    public class Produto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto deve ser inserido!")]
        [MaxLength(255, ErrorMessage = "O tamanho do gênero não pode exceder 255 caracteres")]
        public string Nome { get; set; }

        [MaxLength(255, ErrorMessage = "O tamanho do gênero não pode exceder 255 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Valor do produto é obrigatório!")]
        [Precision(8,2)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O id da categoria deve ser informado!")]
        public virtual Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Quantidade do produto deve ser inserida")]
        public int Quantidade { get; set; }
    }
}