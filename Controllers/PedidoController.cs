using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tavola_api_2.Data;
using Tavola_api_2.Dtos;
using Tavola_api_2.Models;

namespace Tavola_api_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private TavolaContext _context;
        private IMapper _mapper;

        public PedidoController(TavolaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadPedidoDto> Index()
        {
            var pedidos = _context.Pedido.ToList();

            return _mapper.Map<List<ReadPedidoDto>>(pedidos);
        }

        [HttpPost]
        public IActionResult Store([FromBody]Pedido pedido)
        {
            var novoPedido = new Pedido
            {
                Forma_Pagamento = pedido.Forma_Pagamento,
                Status_Pedido = pedido.Status_Pedido,
                Total = pedido.Total
            };

            _context.Pedido.Add(novoPedido);
            _context.SaveChanges();

            foreach (var item in pedido.Itens)
            {
                if (_context.Produtos.Find(item.ProdutoId) == null) return BadRequest();

                var novoItemPedido = new PedidoItens
                {
                    PedidoId = novoPedido.Id,
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade
                };

                _context.PedidoItens.Add(novoItemPedido);
                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Search(int id)
        {
            var pedido = _context.Pedido.FirstOrDefault(pedido => pedido.Id == id);

            if (pedido == null) return NotFound("Pedido não encontrado");

            var mensagem = "Pedido encontrado! Aqui está o Pedido com o ID " + id + ":";
            var resposta = new
            {
                Mensagem = mensagem,
                Produto = pedido
            };

            return Ok(resposta);
        }
    }
}