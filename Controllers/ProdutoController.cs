using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tavola_api_2.Data;
using Tavola_api_2.Data.Dtos;
using Tavola_api_2.Dtos;
using Tavola_api_2.Models;
using System.Linq;

namespace Tavola_api_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private TavolaContext _context;
        private IMapper _mapper;

        public ProdutoController(TavolaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Irá retornar todos os produtos cadastrados /
        /// Se colocar na Url ?categoriaId=ID irá retornar os produtos a partir do Id da categoria.
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <returns>IEnumerable</returns>
        /// <response code="201">Lista com os produtos.</response>
        [HttpGet]
        public IEnumerable<Produto> Index([FromQuery] int? categoriaId = null)
        {
            if(categoriaId == null) {
                var produto = _context.Produtos.Include(produto => produto.Categoria);

                return produto;
            }
            return _context.Produtos.FromSqlRaw($"SELECT Id, Nome, Descricao, Valor, CategoriaId FROM produtos WHERE CategoriaId = {categoriaId}").ToList();
        }

        /// <summary>
        /// Adiciona um produto ao banco de dados
        /// </summary>
        /// <param name="produtoDto">Objeto com os campos necessários para cadastrar um novo produto.</param>
        /// <returns>IactionResult</returns>
        /// <response code="202">Caso ocorra tudo certo.</response>
        [HttpPost]
        public IActionResult Store([FromForm] CreateProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<Produto>(produtoDto);
            var categoria = _context.Categoria.Find(produtoDto.CategoriaId);
            produto.Categoria = categoria;
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Search), new {Id = produto.Id}, produtoDto);
        }

        /// <summary>
        /// Editar um produto a partir de seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produtoDto"></param>
        /// <response code="202">Caso o item exista na base.</response>
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromForm] EditProdutoDto produtoDto)
        {
            var produto = _context.Produtos.Find(id);

            var mensagemNaoEncontrado = "Produto com o Id: " + id + " não encontrado";
            if (produto == null) return NotFound(mensagemNaoEncontrado);

            var categoria = _context.Categoria.Find(produtoDto.CategoriaId);

            produto.Nome = produtoDto.Nome;
            produto.Descricao = produtoDto.Descricao;
            produto.Valor = produtoDto.Valor;
            produto.Categoria = categoria;
            produto.Quantidade = produtoDto.Quantidade;

            _context.Produtos.Update(produto);
            _context.SaveChanges();

            var mensagem = "Produto editado com sucesso!";
            var resposta = new
            {
                Mensagem = mensagem,
                Produto = produto
            };

            return Ok(resposta);
        }

        /// <summary>
        /// Procurar produto através do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns code="202">Caso o produto exista na base de dados.</returns>
        [HttpGet("{id}")]
        public IActionResult Search(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);

            if (produto == null) return NotFound("Produto não encontrado");

            var mensagem = "Produto encontrado! Aqui está o produto com o ID " + id + ":";
            var resposta = new
            {
                Mensagem = mensagem,
                Produto = produto
            };

            return Ok(resposta);
        }

        /// <summary>
        /// Deletar produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns nome="202">Caso o produto exista na base.</returns>
        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            _context.Remove(produto);
            _context.SaveChanges();

            var mensagem = "Produto deletado com sucesso!";
           
            return Ok(mensagem);
        }

        [HttpGet("vendas_por_produto")]
        public IEnumerable<object> TotalVendasDeProdutos()
        {
            var dados = _context.PedidoItens.Include(pi => pi.Produto).ToList();

            var totalVendasPorProduto = dados.GroupBy(pi => pi.Produto.Nome).Select(g => new {
                Produto = g.Key,
                Pedidos = g.Sum(pi => pi.quantidade)
            }).ToList();

            return totalVendasPorProduto;
        }

        [HttpGet("valor_total_vendido")]
        public IEnumerable<object> ValorTotalVendidoPorProduto()
        {
            var dados = _context.PedidoItens.Include(pi => pi.Produto).ToList();

            var valorTotalVendidoPorProduto = dados
                .GroupBy(pi => pi.Produto.Nome)
                .Select(g => new
                {
                    NomeDoProduto = g.Key,
                    ValorTotalVendido = g.Sum(pi => pi.Produto.Valor * pi.quantidade)
                })
                .ToList();

            return valorTotalVendidoPorProduto;
        }

        [HttpGet("alerta_estoque_produto")]
        public IActionResult ProdutosComEstoqueMenorQue10()
        {
            var produtosComEstoqueMenorQue10 = _context.Produtos
                .Where(produto => produto.Quantidade < 10)
                .Select(g => new
                {
                    Produto = g.Nome,
                    Quantidade = g.Quantidade

                })
                .ToList();

            return Ok(produtosComEstoqueMenorQue10);
        }
    }
}
