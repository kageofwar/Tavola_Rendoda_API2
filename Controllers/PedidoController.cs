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
        public IActionResult Store([FromForm]Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            _context.SaveChanges();

            
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