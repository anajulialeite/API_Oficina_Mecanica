using Microsoft.EntityFrameworkCore;
using MinhaAPI.Models;
using SeuProjeto.Models;

namespace MinhaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
        public DbSet<Postagem> Postagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>().ToTable("Telefone");
            modelBuilder.Entity<Postagem>().ToTable("Postagens");
        }

    }
}
