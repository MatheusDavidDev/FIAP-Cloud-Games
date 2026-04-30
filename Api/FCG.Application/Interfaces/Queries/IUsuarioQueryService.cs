using FCG.Application.DTOs;

namespace FCG.Application.Interfaces.Queries;

public interface IUsuarioQueryService
{
    Task<UsuarioDto> ObterUsuarioPorIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<UsuarioDto>> ObterUsuariosAsync(CancellationToken cancellationToken);
}
