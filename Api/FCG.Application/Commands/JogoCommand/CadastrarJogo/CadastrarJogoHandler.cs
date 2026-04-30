using FCG.Core.UnitOfWork;
using FCG.Domain.Entities;
using MediatR;

namespace FCG.Application.Commands.JogoCommand.CadastrarJogo;

public class CadastrarJogoHandler : IRequestHandler<CadastrarJogoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarJogoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CadastrarJogoCommand request, CancellationToken cancellationToken)
    {
        var jogoRepository = _unitOfWork.GetRepository<Jogo>();

        var jogoExistente = await jogoRepository.GetByAsync(predicate: j => j.Nome == request.Nome, cancellationToken: cancellationToken);
        if (jogoExistente is not null)
            throw new Exception("Jogo já existe.");

        var jogo = new Jogo(request.Nome, request.Preco);

        await jogoRepository.AddAsync(jogo, cancellationToken);

        await _unitOfWork.SaveChanges();

    }
}
