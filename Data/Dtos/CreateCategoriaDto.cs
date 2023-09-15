using System.ComponentModel.DataAnnotations;
using Tavola_api_2.Models;

namespace Tavola_api_2.Data.Dtos;
public class CreateCategoriaDto
{
    [Key]
    [Required]
    public int Id{get; set;}

    public string Nome{get;set;}

}