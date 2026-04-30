using Microsoft.EntityFrameworkCore;
using RazorProject.Api.Models;

namespace RazorProject.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Chamado> Chamados => Set<Chamado>();
    public DbSet<Categoria> Categorias => Set<Categoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chamado>(entity =>
        {
            entity.Property(c => c.Titulo).IsRequired().HasMaxLength(200);
            entity.Property(c => c.Descricao).IsRequired().HasMaxLength(2000);
            entity.Property(c => c.Solicitante).IsRequired().HasMaxLength(150);
            entity.Property(c => c.Responsavel).HasMaxLength(150);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        });
    }
}
