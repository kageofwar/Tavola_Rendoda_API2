using Microsoft.EntityFrameworkCore;
using Tavola_api_2.Models;

namespace Tavola_api_2.Data
{
    public class TavolaContext : DbContext
    {
        public TavolaContext(DbContextOptions<TavolaContext> opts) : base(opts)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
