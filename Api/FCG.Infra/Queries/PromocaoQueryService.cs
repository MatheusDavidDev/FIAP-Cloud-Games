using FCG.Application.DTOs;
using FCG.Application.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infra.Queries;

public class PromocaoQueryService : IPromocaoQueryService
{
    private readonly FcgDbContext _context;

    public PromocaoQueryService(FcgDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PromocaoDto>> ObterPromocoesAsync(CancellationToken cancellationToken)
    {
        return await _context.Promocoes
             .Include(x => x.Jogo)
             .Select(x => new PromocaoDto
             {
                 Id = x.Id,
                 IdJogo = x.IdJogo,
                 NomeJogo = x.Jogo.Nome,
                 DataInicio = x.DataInicio,
                 DataFim = x.DataFim,
                 PercentualDesconto = x.PercentualDesconto,
                 Ativa = x.Ativa

             }).ToListAsync(cancellationToken);
    }
}

