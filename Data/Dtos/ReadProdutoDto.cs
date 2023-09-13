using Tavola_api_2.Models;

namespace Tavola_api_2.Data.Dtos
{
    public class ReadProdutoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Valor { get; set; }
        public virtual ICollection<Categoria> Categoria { get; set; }
    }
}
