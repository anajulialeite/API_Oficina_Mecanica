using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using SeuProjeto.Models;

namespace SeuProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnderecosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Endereco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enderecos>>> GetEnderecos()
        {
            var enderecos = await _context.Enderecos.ToListAsync();

            if (enderecos == null || enderecos.Count == 0)
            {
                return NotFound(new { message = "Nenhum endereço encontrado." });
            }

            return Ok(new { message = "Endereços encontrados com sucesso.", data = enderecos });
        }

        // GET: api/Endereco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enderecos>> GetEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
            {
                return NotFound(new { message = "Endereço não encontrado." });
            }

            return Ok(new { message = "Endereço encontrado com sucesso.", data = endereco });
        }

        // POST: api/Endereco
        [HttpPost]
        public async Task<ActionResult<Enderecos>> PostEndereco(Enderecos endereco)
        {
            var enderecoExistente = await _context.Enderecos
                .FirstOrDefaultAsync(e => e.Cep == endereco.Cep);

            if (enderecoExistente != null)
            {
                return Conflict(new { message = "Já existe um endereço com esse CEP." });
            }

            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEndereco), new { id = endereco.EnderecoId },
                new { message = "Endereço criado com sucesso.", data = endereco });
        }

        // PUT: api/Endereco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Enderecos endereco)
        {
            if (id != endereco.EnderecoId)
            {
                return BadRequest(new { message = "ID do endereço não corresponde ao ID enviado." });
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
                {
                    return NotFound(new { message = "Endereço não encontrado." });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Endereço atualizado com sucesso.", data = endereco });
        }

        // DELETE: api/Endereco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound(new { message = "Endereço não encontrado." });
            }

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Endereço deletado com sucesso." });
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.EnderecoId == id);
        }
    }
}
