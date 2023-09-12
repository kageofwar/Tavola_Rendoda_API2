using System.ComponentModel.DataAnnotations;
using Tavola_api_2.Models;

namespace Tavola_api_2.Data.Dtos;

public class CreateProdutoDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto deve ser inserido!")]
    public string Nome { get; set; }

    public string Descricao { get; set; }

    [Required(ErrorMessage = "O Valor do produto é obrigatório!")]
    public int Valor { get; set; }

    [Required(ErrorMessage = "O id da categoria deve ser informado!")]
    public int CategoriaId { get; set; } 
}
