using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.ExcluirUsuario;

public class ExcluirUsuarioCommand : IRequest
{
    public ExcluirUsuarioCommand(Guid idUsuario)
    {
        IdUsuario = idUsuario;
    }

    public Guid IdUsuario { get; set; }
}
