using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaAPI.Data;
using OficinaAPI.Models;

namespace OficinaDeAutomoveis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly OficinaContext _context;

        public AgendamentoController(OficinaContext context)
        {
            _context = context;
        }

        // GET: api/Agendamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
        {
            var lista = await _context.Agendamentos
                .Include(a => a.Cliente)  // Inclui a entidade Cliente
                .Include(a => a.Veiculo)  // Inclui a entidade Veiculo
                .Include(a => a.Funcionario) // Inclui a entidade Funcionario
                .ToListAsync();

            if (lista == null || !lista.Any())
                return NotFound("Nenhum agendamento encontrado.");

            return Ok(lista);
        }

        // GET: api/Agendamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos
                .Include(a => a.Cliente)  // Inclui a entidade Cliente
                .Include(a => a.Veiculo)  // Inclui a entidade Veiculo
                .Include(a => a.Funcionario) // Inclui a entidade Funcionario
                .FirstOrDefaultAsync(a => a.AgendamentoID == id);

            if (agendamento == null)
                return NotFound($"Agendamento com ID {id} não encontrado.");

            return Ok(agendamento);
        }

        // POST: api/Agendamento
        [HttpPost]
        public async Task<ActionResult> PostAgendamento(Agendamento agendamento)
        {
            if (agendamento.ClienteID == 0 || agendamento.VeiculoID == 0) // Verificando se o ClienteID e VeiculoID foram fornecidos corretamente
                return BadRequest("Cliente e Veículo devem ser informados para criar o agendamento.");

            // Verificando se o cliente e o veículo existem no banco
            var clienteExistente = await _context.Clientes.AnyAsync(c => c.ClienteID == agendamento.ClienteID);
            var veiculoExistente = await _context.Veiculos.AnyAsync(v => v.VeiculoID == agendamento.VeiculoID);

            if (!clienteExistente)
                return BadRequest("Cliente informado não encontrado.");

            if (!veiculoExistente)
                return BadRequest("Veículo informado não encontrado.");

            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgendamento), new { id = agendamento.AgendamentoID }, agendamento);
        }

        // PUT: api/Agendamento/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAgendamento(int id, Agendamento agendamento)
        {
            if (id != agendamento.AgendamentoID)
                return BadRequest("O ID do agendamento não corresponde ao enviado.");

            var existe = await _context.Agendamentos.AnyAsync(a => a.AgendamentoID == id);
            if (!existe)
                return NotFound($"Agendamento com ID {id} não encontrado.");

            _context.Entry(agendamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Agendamento atualizado com sucesso.");
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Erro ao atualizar o agendamento. Tente novamente.");
            }
        }

        // DELETE: api/Agendamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
                return NotFound($"Agendamento com ID {id} não encontrado.");

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return Ok("Agendamento removido com sucesso.");
        }
    }
}
