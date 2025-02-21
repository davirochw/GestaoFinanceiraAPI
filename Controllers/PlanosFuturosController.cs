using Microsoft.AspNetCore.Mvc;
using GestaoFinanceiraAPI.Models;

namespace GestaoFinanceiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosFuturosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlanosFuturosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PlanosFuturos
        [HttpGet]
        public ActionResult<IEnumerable<PlanoFuturo>> GetPlanosFuturos()
        {
            return _context.PlanosFuturos.ToList();
        }

        // GET: api/PlanosFuturos/5
        [HttpGet("{id}")]
        public ActionResult<PlanoFuturo> GetPlanoFuturo(int id)
        {
            var planoFuturo = _context.PlanosFuturos.Find(id);

            if (planoFuturo == null)
            {
                return NotFound();
            }

            return planoFuturo;
        }

        // POST: api/PlanosFuturos
        [HttpPost]
        public ActionResult<PlanoFuturo> PostPlanoFuturo(PlanoFuturo planoFuturo)
        {
            _context.PlanosFuturos.Add(planoFuturo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPlanoFuturo), new { id = planoFuturo.Id }, planoFuturo);
        }

        // PUT: api/PlanosFuturos/5
        [HttpPut("{id}")]
        public IActionResult PutPlanoFuturo(int id, PlanoFuturo planoFuturo)
        {
            if (id != planoFuturo.Id)
            {
                return BadRequest();
            }

            _context.Entry(planoFuturo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/PlanosFuturos/5
        [HttpDelete("{id}")]
        public IActionResult DeletePlanoFuturo(int id)
        {
            var planoFuturo = _context.PlanosFuturos.Find(id);

            if (planoFuturo == null)
            {
                return NotFound();
            }

            _context.PlanosFuturos.Remove(planoFuturo);
            _context.SaveChanges();

            return NoContent();
        }

        // GET: api/PlanosFuturos/5/calcular-economia
        [HttpGet("{id}/calcular-economia")]
        public ActionResult<decimal> CalcularEconomiaMensal(int id)
        {
            var planoFuturo = _context.PlanosFuturos.Find(id);

            if (planoFuturo == null)
            {
                return NotFound();
            }

            var mesesRestantes = (planoFuturo.Prazo - DateTime.Now).Days / 30;
            if (mesesRestantes <= 0)
            {
                return BadRequest("O prazo para este plano já expirou.");
            }

            var economiaMensal = planoFuturo.ValorNecessario / mesesRestantes;

            return Ok(economiaMensal);
        }
    }
}