using FCG.Application.DTOs;
using FCG.Application.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infra.Queries;

public class BibliotecaQueryService : IBibliotecaQueryService
{
    private readonly FcgDbContext _context;

    public BibliotecaQueryService(FcgDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BibliotecaDto>> ObterBibliotecaPorIdUsuarioAsync(Guid idUsuario, CancellationToken cancellationToken)
    {
       return await _context.JogosBiblioteca
            .Where(x => x.IdUsuario == idUsuario)
            .Select(x => new BibliotecaDto
            {
                Id = x.Id,
                IdJogo = x.IdJogo,
                NomeJogo = x.Jogo.Nome,
                DataAdd = x.CreatedAt

            }).ToListAsync(cancellationToken);
    }
}
