using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.EditarUsuario;

public class EditarUsuarioHandler : IRequestHandler<EditarUsuarioCommand>
{
    public EditarUsuarioHandler()
    {
        
    }

    public Task Handle(EditarUsuarioCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
