using Microsoft.AspNetCore.Mvc;
using GestaoFinanceiraAPI.Models;

namespace GestaoFinanceiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartoesCreditoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartoesCreditoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CartoesCredito
        [HttpGet]
        public ActionResult<IEnumerable<CartaoCredito>> GetCartoesCredito()
        {
            return _context.CartoesCredito.ToList();
        }

        // POST: api/CartoesCredito
        [HttpPost]
        public ActionResult<CartaoCredito> PostCartaoCredito(CartaoCredito cartaoCredito)
        {
            _context.CartoesCredito.Add(cartaoCredito);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCartoesCredito), new { id = cartaoCredito.Id }, cartaoCredito);
        }
    }
}