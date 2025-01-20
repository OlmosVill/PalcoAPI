using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalcoAPI.ErikasModels;
using static PalcoAPI.OthersModels.Models;

namespace PalcoAPI.Controllers
{
    [Route("Palco")]
    [ApiController]
    public class PalcoController : ControllerBase
    {
        private readonly MiDbContext _context;

        public PalcoController(MiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok("API is running");

        // GET: api/Previo
        [HttpGet("/GetMensajitos")]
        public async Task<ActionResult<IEnumerable<Mensajito>>> GetMensajito()
        {
            return await _context.Mensajitos.ToListAsync();
        }

        // POST: api/Previo
        [HttpPost]
        public async Task<ActionResult<Mensajito>> PostMensajito(Mensajito msg)
        {
            _context.Mensajitos.Add(msg);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMensajito), new { id = msg.Id }, msg);
        }
    }
}
