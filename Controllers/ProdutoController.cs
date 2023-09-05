using Microsoft.AspNetCore.Mvc;
using Tavola_api_2.Data;
using Tavola_api_2.Data.Dtos;
using Tavola_api_2.Models;

namespace Tavola_api_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private TavolaContext _context;

        public ProdutoController(TavolaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Irá retornar todos os produtos cadastrados
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="201">Lista com os produtos.</response>
        [HttpGet]
        public IEnumerable<Produto> Index()
        {
            return _context.Produtos;
        }

        /// <summary>
        /// Adiciona um produto ao banco de dados
        /// </summary>
        /// <param name="produtoDto">Objeto com os campos necessários para cadastrar um novo produto.</param>
        /// <returns>IactionResult</returns>
        /// <response code="202">Caso ocorra tudo certo.</response>
        [HttpPost]
        public IActionResult Store([FromBody] CreateProdutoDto produtoDto)
        {
            Produto produto = new Produto()
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                Valor = produtoDto.Valor,
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            var mensagem = "Produto cadastrado com sucesso!";
            var resposta = new
            {
                Mensagem = mensagem,
                Produto = produto
            };

            return Ok(resposta);
        }

        /// <summary>
        /// Editar um produto a partir de seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produtoDto"></param>
        /// <response code="202">Caso o item exista na base.</response>
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] EditProdutoDto produtoDto)
        {
            var produto = _context.Produtos.Find(id);

            var mensagemNaoEncontrado = "Produto com o Id: " + id + " não encontrado";
            if (produto == null) return NotFound(mensagemNaoEncontrado);

            produto.Nome = produtoDto.Nome;
            produto.Descricao = produtoDto.Descricao;
            produto.Valor = produtoDto.Valor;

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
        [HttpGet("teste/{id}")]
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
    }
}
