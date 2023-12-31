using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tavola_api_2.Data;
using Tavola_api_2.Dtos;
using Tavola_api_2.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.JsonPatch;


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
                pagamento = pedido.pagamento,
                status = pedido.status,
                total = pedido.total
            };

            _context.Pedido.Add(novoPedido);
            _context.SaveChanges();

            foreach (var item in pedido.itens)
            {
                var produto = _context.Produtos.Find(item.produtoId);

                if (produto == null || produto.Quantidade < item.quantidade)
                {
                    return BadRequest("Produto não encontrado ou estoque insuficiente.");
                }

                produto.Quantidade -= item.quantidade;

                if (_context.Produtos.Find(item.produtoId) == null) return BadRequest();

                var novoItemPedido = new PedidoItens
                {
                    pedidoId = novoPedido.Id,
                    produtoId = item.produtoId,
                    quantidade = item.quantidade
                };

                _context.PedidoItens.Add(novoItemPedido);
                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Search(int id)
        {
            var pedido = _context.Pedido
            .Include(p => p.itens)
            .ThenInclude(i => i.Produto)
            .FirstOrDefault(p => p.Id == id);

            if (pedido == null) return BadRequest();
            
            return Ok(pedido);
        }

        [HttpPatch("{id}")]
        public IActionResult PedidoParcial(int id, [FromBody] PedidoFlag req)
        {
            var pedido = _context.Pedido.FirstOrDefault(
                pedido => pedido.Id == id);
            if (pedido == null) return NotFound();

            var pedidoAtualizar = _mapper.Map<UpdatePedidoDto>(pedido);
            if(req.flag == "client") {
                pedidoAtualizar.status = "Finalizado";
            } else if(pedido.status == "Recebido") {
                pedidoAtualizar.status = "Em Andamento";
            } else if (pedido.status == "Em Andamento") {
                pedidoAtualizar.status = "Enviado";
            } else {
                pedidoAtualizar.status = "Recebido";
            }

            //patch.ApplyTo(pedidoAtualizar, ModelState);

            //if (!TryValidateModel(pedidoAtualizar))
            //{
            //    return ValidationProblem(ModelState);
            //}
            _mapper.Map(pedidoAtualizar, pedido);
            _context.SaveChanges();
            return NoContent();
        }
    }
}