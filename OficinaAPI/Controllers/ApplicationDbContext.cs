
using Microsoft.EntityFrameworkCore;
using OficinaAPI.Models;

namespace OficinaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CustoMaoDeObra> CustoMaoDeObras { get; set; }
        public DbSet<Reparacao> Reparacoes { get; set; }
        public DbSet<PecaUtilizada> PecasUtilizadas { get; set; }
        public DbSet<TempoMaoDeObra> TemposMaoDeObra { get; set; }
        public DbSet<PecaEmArmazem> PecasEmArmazem { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<FeedbackCliente> FeedbacksClientes { get; set; }
        public DbSet<ControleDePermissao> ControlesDePermissao { get; set; }
        public DbSet<DocumentoImagem> DocumentosImagens { get; set; }
        public DbSet<RelatorioEstatistica> RelatoriosEstatisticas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
    }
}
