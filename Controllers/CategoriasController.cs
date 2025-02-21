using Microsoft.AspNetCore.Mvc;
using GestaoFinanceiraAPI.Models;

namespace GestaoFinanceiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            return _context.Categorias.ToList();
        }
    }
}