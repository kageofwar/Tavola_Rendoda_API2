using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tavola_api_2.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "O nome do produto não pode ter mais que 255 caracteres")]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}