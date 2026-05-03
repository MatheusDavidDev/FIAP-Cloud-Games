using FCG.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infra;

public class FcgDbContext : DbContext
{
    public FcgDbContext(DbContextOptions<FcgDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<JogoBiblioteca> JogosBiblioteca { get; set; }
    public DbSet<Jogo> Jogos { get; set; }
    public DbSet<Promocao> Promocoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FcgDbContext).Assembly);
    }
}
