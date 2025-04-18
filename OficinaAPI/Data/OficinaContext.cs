using Microsoft.EntityFrameworkCore;
using OficinaAPI.Models;

namespace OficinaAPI.Data
{
    public class OficinaContext : DbContext
    {
        public OficinaContext(DbContextOptions<OficinaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<CustoMaoDeObra> custoMaoDeObras { get; set; }
        public DbSet<Reparacao> reparaçãos { get; set; }
        public DbSet<PecaUtilizada> pecaUtilizadas { get; set; }
        public DbSet<TempoMaoDeObra> tempoMaoDeObras { get; set; }
        public DbSet<PecaEmArmazem> pecaEmArmazems { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Pagamento> pagamentos { get; set; }
        public DbSet<FeedbackCliente> feedbackClientes { get; set; }
        public DbSet<ControleDePermissao> controleDePermissoes { get; set; }
        public DbSet<DocumentoImagem> documentoImagens { get; set; }
        public DbSet<RelatorioEstatistica> relatorioEstatisticas { get; set; }
        public DbSet<Contato> contatos { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
