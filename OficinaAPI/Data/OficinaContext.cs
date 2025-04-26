using Microsoft.EntityFrameworkCore;
using OficinaAPI.Models;

namespace OficinaAPI.Data
{
    public class OficinaContext : DbContext
    {
        public OficinaContext(DbContextOptions<OficinaContext> options) : base(options) { }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento entre Agendamento e Cliente
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Cliente)
                .WithMany()  // Não há navegação reversa, se houver, use o nome da coleção de Agendamentos
                .HasForeignKey(a => a.ClienteID)
                .IsRequired();  // Caso Cliente seja obrigatório (caso contrário, omita o IsRequired)

            // Relacionamento entre Agendamento e Veiculo
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Veiculo)
                .WithMany()  // Similar ao anterior, com navegação reversa se necessário
                .HasForeignKey(a => a.VeiculoID)
                .IsRequired();  // Se necessário, remova o IsRequired conforme o caso

            // Relacionamento entre Agendamento e Funcionario
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Funcionario)
                .WithMany()  // Similar ao anterior, com navegação reversa se necessário
                .HasForeignKey(a => a.FuncionarioID)
                .IsRequired(false);  // Como Funcionario pode ser nulo, usamos IsRequired(false)
        }
    }
}
