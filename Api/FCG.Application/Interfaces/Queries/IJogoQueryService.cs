using FCG.Application.DTOs;

namespace FCG.Application.Interfaces.Queries;

public interface IJogoQueryService
{
    Task<JogoDto> ObterJogoPorIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<JogoDto>> ObterJogoAsync(CancellationToken cancellationToken);
}
