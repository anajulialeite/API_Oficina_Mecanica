using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;
using SeuProjeto.Models;

namespace MinhaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostagensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostagensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Postagem
        [HttpGet]
        public async Task<IActionResult> GetPostagens()
        {
            var postagem = await _context.Postagens.ToListAsync();
            return Ok(new { mensagem = "Lista de postagens obtida com sucesso.", dados = postagem });
        }

        // GET: api/Postagem/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostagem(int id)
        {
            var postagem = await _context.Postagens.FindAsync(id);

            if (postagem == null)
            {
                return NotFound(new { mensagem = "Postagem não encontrada." });
            }

            return Ok(new { mensagem = "Postagem encontrada.", dados = postagem });
        }

        // POST: api/Postagem
        [HttpPost]
        public async Task<IActionResult> CriarPostagem(Postagem postagem)
        {
            postagem.DataCriacao = DateTime.UtcNow;
            _context.Postagens.Add(postagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostagem), new { id = postagem.PostagemId }, new
            {
                mensagem = "Postagem criada com sucesso.",
                dados = postagem
            });
        }

        // PUT: api/Postagem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPostagem(int id, Postagem postagem)
        {
            if (id != postagem.PostagemId)
            {
                return BadRequest(new { mensagem = "ID da URL não confere com o corpo da requisição." });
            }

            _context.Entry(postagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Postagens.Any(e => e.PostagemId == id))
                {
                    return NotFound(new { mensagem = "Postagem não encontrada para atualizar." });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { mensagem = "Postagem atualizada com sucesso." });
        }

        // DELETE: api/Postagem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPostagem(int id)
        {
            var postagem = await _context.Postagens.FindAsync(id);
            if (postagem == null)
            {
                return NotFound(new { mensagem = "Postagem não encontrada para exclusão." });
            }

            _context.Postagens.Remove(postagem);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Postagem excluída com sucesso." });
        }
    }
}

