using FCG.Application.DTOs;

namespace FCG.Application.Interfaces.Queries;

public interface IPromocaoQueryService
{
    Task<IEnumerable<PromocaoDto>> ObterPromocoesAsync(CancellationToken cancellationToken);
}
