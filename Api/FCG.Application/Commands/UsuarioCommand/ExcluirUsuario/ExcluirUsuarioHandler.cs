using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.ExcluirUsuario;

public class ExcluirUsuarioHandler : IRequestHandler<ExcluirUsuarioCommand>
{
    public ExcluirUsuarioHandler()
    {
        
    }

    public async Task Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
