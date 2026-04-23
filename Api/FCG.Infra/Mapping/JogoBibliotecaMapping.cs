using FCG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infra.Mapping;

public class JogoBibliotecaMapping : IEntityTypeConfiguration<JogoBiblioteca>
{
    public void Configure(EntityTypeBuilder<JogoBiblioteca> builder)
    {
        builder.ToTable("JogoBiblioteca");

        builder.HasOne(x => x.Jogo)
            .WithMany(x => x.JogoBiblioteca)
            .HasForeignKey(x => x.IdJogo);

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.Jogos)
            .HasForeignKey(x => x.IdUsuario);
    }
}
