using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.AdicionarJogo;

public class AdicionarJogoCommand : IRequest
{
    public AdicionarJogoCommand(Guid idUsuario, Guid idJogo)
    {
        IdUsuario = idUsuario;
        IdJogo = idJogo;
    }

    public Guid IdUsuario { get; set; }
    public Guid IdJogo { get; set; }
}
