using FCG.Application.DTOs;

namespace FCG.Application.Interfaces.Queries;

public interface IBibliotecaQueryService
{
    Task<IEnumerable<BibliotecaDto>> ObterBibliotecaPorIdUsuarioAsync(Guid idUsuario, CancellationToken cancellationToken);
}
