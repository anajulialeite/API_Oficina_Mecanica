using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MinhaAPI.Data;
using MinhaAPI.Models;
using MinhaApi.Services;
namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Usuario>>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(new ApiResponse<IEnumerable<Usuario>>(true, "Lista de usuários obtida com sucesso.", usuarios));
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Usuario>>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(new ApiResponse<Usuario>(false, "Usuário não encontrado."));
            }

            return Ok(new ApiResponse<Usuario>(true, "Usuário encontrado com sucesso.", usuario));
        }

        // POST: api/Usuario
        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Usuario>>> PostUsuario(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
            {
                return BadRequest(new ApiResponse<Usuario>(false, "Nome, Email e Senha são obrigatórios."));
            }

            // GERA O HASH DA SENHA AQUI
            usuario.Senha = HashService.GerarHash(usuario.Senha);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, new ApiResponse<Usuario>(true, "Usuário criado com sucesso.", usuario));
        }


        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Usuario>>> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest(new ApiResponse<Usuario>(false, "O ID informado é diferente do ID do usuário."));
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound(new ApiResponse<Usuario>(false, "Usuário não encontrado para atualização."));
                }
                else
                {
                    throw;
                }
            }

            return Ok(new ApiResponse<Usuario>(true, "Usuário atualizado com sucesso.", usuario));
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(new ApiResponse<object>(false, "Usuário não encontrado para exclusão."));
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<object>(true, "Usuário excluído com sucesso."));
        }

        // GET: api/Usuario/buscar?nome=Ana
        [HttpGet("buscar")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Usuario>>>> BuscarUsuariosPorNome([FromQuery] string nome)
        {
            // LINQ para buscar usuários pelo nome
            var usuarios = await _context.Usuarios
                .Where(u => u.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();

            // Se não encontrar ninguém, retorna 404
            if (usuarios == null || usuarios.Count == 0)
            {
                return NotFound(new ApiResponse<IEnumerable<Usuario>>(false, "Nenhum usuário encontrado com esse nome."));
            }

            // Se encontrar, retorna 200 com a lista de usuários
            return Ok(new ApiResponse<IEnumerable<Usuario>>(true, "Usuários encontrados com sucesso.", usuarios));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }

        // Novo método para testar o hash da senha
        [HttpGet("testar-hash")]
        public IActionResult TestarHash()
        {
            // Senha que você quer testar
            string senhaOriginal = "MinhaSenha123";

            // Gera o hash da senha
            string senhaHash = HashService.GerarHash(senhaOriginal);

            // Retorna o resultado com a senha original e o hash gerado
            return Ok(new ApiResponse<object>(true, "Teste de hash realizado com sucesso.", new
            {
                SenhaOriginal = senhaOriginal,
                SenhaHash = senhaHash
            }));
        }

    }
}
