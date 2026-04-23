using FCG.Core.Models;

namespace FCG.Domain.Entities;

public class JogoBiblioteca : BaseEntity
{
    public JogoBiblioteca(Guid idUsuario, Guid idJogo)
    {
        IdUsuario = idUsuario;
        IdJogo = idJogo;
    }

    public Guid IdUsuario { get; private set; }
    public Usuario Usuario { get; private set; }
    public Guid IdJogo { get; private set; }
    public Jogo Jogo { get; private set; }
}

