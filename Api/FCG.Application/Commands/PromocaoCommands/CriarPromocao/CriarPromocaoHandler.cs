using FCG.Core.UnitOfWork;
using FCG.Domain.Entities;
using MediatR;

namespace FCG.Application.Commands.PromocaoCommands.CriarPromocao;

public class CriarPromocaoHandler : IRequestHandler<CriarPromocaoCommad>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarPromocaoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CriarPromocaoCommad request, CancellationToken cancellationToken)
    {
        var promocaoRepository = _unitOfWork.GetRepository<Promocao>();
        var jogoRepository = _unitOfWork.GetRepository<Jogo>();

        var jogoExistente = await jogoRepository.GetByAsync(predicate: x => x.Id == request.IdJogo, cancellationToken: cancellationToken);
        
        if (jogoExistente is null)
            throw new Exception("Jogo não encontrado.");

        var promocaoExistente = await promocaoRepository.GetByAsync(
            predicate: x => x.IdJogo == request.IdJogo &&
            x.DataFim > DateTime.Now &&
            x.Ativa == true, 
            
            cancellationToken: cancellationToken);

        if (promocaoExistente is not null)
            throw new Exception("já existe promoção ativa para esse jogo.");

        var promocao = new Promocao(request.IdJogo, request.PorcentagemDesconto, request.DataInicio, request.DataFim);

        await promocaoRepository.AddAsync(promocao, cancellationToken);

        await _unitOfWork.SaveChanges();
    }
}
