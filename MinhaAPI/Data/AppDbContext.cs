﻿using Microsoft.EntityFrameworkCore;
using MinhaAPI.Models;

namespace MinhaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } // DbSet para a tabela Usuario
    }
}
