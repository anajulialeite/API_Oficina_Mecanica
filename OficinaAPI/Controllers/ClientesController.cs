using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaAPI.Data;
using OficinaAPI.Models;

namespace OficinaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly OficinaContext _context;

        public ClientesController(OficinaContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _context.Clientes
        .Select(c => new Cliente
        {
            ClienteID = c.ClienteID,
            Nome = c.Nome,
            DataNascimento = c.DataNascimento.HasValue ? c.DataNascimento.Value : (DateTime?)null,  // Tratar o valor nulo
            Genero = c.Genero,
            CPF = c.CPF,
            EstadoCivil = c.EstadoCivil,
            Observacao = c.Observacao
        }).ToListAsync();

            return Ok(clientes);
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado no sistema da oficina");
            }

            return cliente;
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.ClienteID }, new
            {
                mensagem = "Cliente cadastrado com sucesso na oficina",
                dados = cliente
            });
        }

        // PUT: api/clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ClienteID)
            {
                return BadRequest("ID informado não confere com o do cliente enviado. Verifique e tente novamente.");
            }

            // Verificar se DataNascimento é null antes de realizar qualquer operação com ela
            if (cliente.DataNascimento.HasValue)
            {
                // Aqui você pode realizar operações com a DataNascimento, se necessário
                // Por exemplo, calcular a idade ou qualquer outra lógica
            }
            else
            {
                // Se DataNascimento for null, você pode definir um valor padrão ou tratar de outra maneira
                cliente.DataNascimento = null; // Se for para continuar com o valor nulo
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clientes.Any(e => e.ClienteID == id))
                {
                    return NotFound("Cliente não encontrado no sistema da oficina.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Dados do cliente atualizados com sucesso!");
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado no banco de dados da oficina.");
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente removido com sucesso do sistema da oficina!");
        }
    }
}
