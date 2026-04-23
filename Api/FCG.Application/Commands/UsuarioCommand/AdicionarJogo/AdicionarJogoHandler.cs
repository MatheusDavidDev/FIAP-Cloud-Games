using FCG.Core.UnitOfWork;
using FCG.Domain.Entities;
using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.AdicionarJogo;

public class AdicionarJogoHandler : IRequestHandler<AdicionarJogoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AdicionarJogoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AdicionarJogoCommand request, CancellationToken cancellationToken)
    {
        var usuarioRepository = _unitOfWork.GetRepository<Usuario>();
        var jogoRepository = _unitOfWork.GetRepository<Jogo>();

        var usuario = await usuarioRepository.GetByAsync(u => u.Id == request.IdUsuario, cancellationToken);

        if (usuario is null)
            throw new Exception("Usuário não encontrado.");

        var jogo = await jogoRepository.GetByAsync(j => j.Id == request.IdJogo, cancellationToken);

        if (jogo is null)
            throw new Exception("Jogo não encontrado.");

        var jogoBiblioteca = new JogoBiblioteca(request.IdUsuario, request.IdJogo);

        usuario.AdicionarJogo(jogoBiblioteca);

        usuarioRepository.Update(usuario);  

        await _unitOfWork.SaveChanges();
    }
}
