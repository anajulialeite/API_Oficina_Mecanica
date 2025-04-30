using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using SeuProjeto.Models;

namespace SeuProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TelefoneController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Telefone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefones()
        {
            var telefone = await _context.Telefones.ToListAsync();

            if (telefone != null && telefone.Count != 0)
            {
                return Ok(new { message = "Telefones encontrados com sucesso.", data = telefone });
            }

            return NotFound(new { message = "Nenhum telefone encontrado." });
        }

        // GET: api/Telefone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> GetTelefone(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);

            if (telefone == null)
            {
                return NotFound(new { message = "Telefone não encontrado." });
            }

            return Ok(new { message = "Telefone encontrado com sucesso.", data = telefone });
        }

        // POST: api/Telefone
        [HttpPost]
        public async Task<ActionResult<Telefone>> PostTelefone(Telefone telefone)
        {
            // Verificando se já existe um telefone com o mesmo número
            var telefoneExistente = await _context.Telefones
                .FirstOrDefaultAsync(t => t.Numero == telefone.Numero);

            if (telefoneExistente != null)
            {
                return Conflict(new { message = "Já existe um telefone com esse número." });
            }

            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTelefone), new { id = telefone.TelefoneId },
                new { message = "Telefone criado com sucesso.", data = telefone });
        }

        // PUT: api/Telefone/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefone(int id, Telefone telefone)
        {
            if (id != telefone.TelefoneId)
            {
                return BadRequest(new { message = "ID do telefone não corresponde ao ID enviado." });
            }

            _context.Entry(telefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(id))
                {
                    return NotFound(new { message = "Telefone não encontrado." });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Telefone atualizado com sucesso.", data = telefone });
        }

        // DELETE: api/Telefone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefone(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone == null)
            {
                return NotFound(new { message = "Telefone não encontrado." });
            }

            _context.Telefones.Remove(telefone);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Telefone deletado com sucesso." });
        }

        private bool TelefoneExists(int id)
        {
            return _context.Telefones.Any(e => e.TelefoneId == id);
        }
    }
}
