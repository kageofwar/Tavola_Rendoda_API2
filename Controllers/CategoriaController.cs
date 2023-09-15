using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tavola_api_2.Data;
using Tavola_api_2.Data.Dtos;
using Tavola_api_2.Models;

namespace Tavola_api_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private TavolaContext _context;
        private IMapper _mapper;

        public CategoriaController(TavolaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadCategoriaDto> Index()
        {
            return _mapper.Map<List<ReadCategoriaDto>>(_context.Categoria.ToList());
        }

        [HttpPost]
        public IActionResult Store([FromForm]Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
            return Ok();
        }
    }
}
