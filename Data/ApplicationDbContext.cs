using GestaoFinanceiraAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Tabelas do banco de dados
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Despesa> Despesas { get; set; }
    public DbSet<CartaoCredito> CartoesCredito { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<PlanoFuturo> PlanosFuturos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações adicionais (opcional)
        modelBuilder.Entity<CartaoCredito>()
            .HasOne(c => c.Usuario)
            .WithMany(u => u.CartoesCredito)
            .HasForeignKey(c => c.UsuarioId);

        modelBuilder.Entity<PlanoFuturo>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.PlanosFuturos)
            .HasForeignKey(p => p.UsuarioId);

        modelBuilder.Entity<Despesa>()
            .HasOne(d => d.Usuario)
            .WithMany(u => u.Despesas)
            .HasForeignKey(d => d.UsuarioId);

        // Popular categorias iniciais
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nome = "Alimentação", Tipo = "Essencial" },
            new Categoria { Id = 2, Nome = "Saúde", Tipo = "Essencial" },
            new Categoria { Id = 3, Nome = "Lazer", Tipo = "Não Essencial" },
            new Categoria { Id = 4, Nome = "Investimentos", Tipo = "Essencial" }
        );
    }
}