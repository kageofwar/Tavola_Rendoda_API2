using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tavola_api_2.Models
{
    public class PedidoFlag
    {
        public string? flag { get; set; }
    }
}