using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalcoAPI.Models;
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
        [HttpGet("/GetPrevios")]
        public async Task<ActionResult<IEnumerable<Previo>>> GetPrevios()
        {
            return await _context.Previos.Include(x => x.PrevioRows).ToListAsync();
        }

        // GET: api/Previo/{id}
        [HttpGet("{guiaHouse}")]
        public async Task<ActionResult<Previo>> GetPrevio(string guiaHouse)
        {
            var previo = await _context.Previos.FindAsync(guiaHouse);
            if (previo == null) return NotFound();

            return previo;
        }

        // POST: api/Previo
        [HttpPost]
        public async Task<ActionResult<Previo>> PostPrevio(Previo previo)
        {
            // Configurar el modelo manualmente antes de guardar
            foreach (var row in previo.PrevioRows)
            {
                row.IdGuiaHouseNavigation = null; // Asegúrate de que esté vacío
            }

            _context.Previos.Add(previo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPrevio), new { guiaHouse = previo.GuiaHouse }, previo);
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Username and password are required");
            }

            var user = _context.Users
                .Where(u => u.Username == loginModel.Username && u.Password == loginModel.Password)
                .FirstOrDefault();

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(new { user.IdUser, user.Username, user.Role });
        }
    }
}
