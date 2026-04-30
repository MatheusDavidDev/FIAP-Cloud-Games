using FCG.Core.UnitOfWork;
using FCG.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FCG.Application.Commands.BibliotecaCommand.AdicionarJogo;

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
        var bibliotecaRepository = _unitOfWork.GetRepository<JogoBiblioteca>();
        var jogoRepository = _unitOfWork.GetRepository<Jogo>();

        var usuario = await usuarioRepository.GetByAsync(
            predicate: u => u.Id == request.IdUsuario, 
            include: i => i.Include(x => x.Jogos));

        if (usuario is null)
            throw new Exception("Usuário não encontrado.");

        var jogo = await jogoRepository.GetByAsync(
            predicate: j => j.Id == request.IdJogo, 
            cancellationToken: cancellationToken);

        if (jogo is null)
            throw new Exception("Jogo não encontrado.");

        var jogoBiblioteca = new JogoBiblioteca(request.IdUsuario, request.IdJogo);

    
        usuario.AdicionarJogo(jogoBiblioteca);

        await bibliotecaRepository.AddAsync(jogoBiblioteca, cancellationToken);

        await _unitOfWork.SaveChanges();
    }
}
