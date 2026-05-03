using MediatR;

namespace FCG.Application.Commands.UsuarioCommands.ExcluirUsuario;

public class ExcluirUsuarioHandler : IRequestHandler<ExcluirUsuarioCommand>
{
    public ExcluirUsuarioHandler()
    {
        
    }

    public Task Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
