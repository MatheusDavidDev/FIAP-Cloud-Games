using FCG.Application.DTOs;
using FCG.Application.Interfaces.Queries;
using FCG.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infra.Queries;

public class JogoQueryService : IJogoQueryService
{
    private readonly FcgDbContext _context;

    public JogoQueryService(FcgDbContext context)
    {
        _context = context;
    }

    public async Task<JogoDto> ObterJogoPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var jogo = await _context.Jogos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (jogo == null)
            return null;

        return new JogoDto
        {
            Id = jogo.Id,
            Nome = jogo.Nome,
            Preco = jogo.Preco
        };
    }

    public async Task<IEnumerable<JogoDto>> ObterJogoAsync(CancellationToken cancellationToken)
    {
        var usuarios = await _context.Jogos.ToListAsync(cancellationToken);
        return usuarios.OrderByDescending(x => x.CreatedAt)
            .Select(x => new JogoDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Preco = x.Preco
            });
    }


}
