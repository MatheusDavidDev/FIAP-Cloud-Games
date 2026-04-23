using FCG.Core.UnitOfWork;
using FCG.Domain.Entities;
using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.EditarUsuario;

public class EditarUsuarioHandler : IRequestHandler<EditarUsuarioCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public EditarUsuarioHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(EditarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuarioRepository = _unitOfWork.GetRepository<Usuario>();

        var usuario = await usuarioRepository.GetByAsync(x => x.Id == request.IdUsuario, cancellationToken);
        if (usuario is null)
            throw new Exception("Usuário não encontrado.");

        usuario.Editar(request.Nome, request.Tipo);

        usuarioRepository.Update(usuario);

        await _unitOfWork.SaveChanges();
    }
}
