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
        var jogo = await _context.Jogos.Include(x => x.Promocoes).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        var dataAtual = DateTime.Now;

        var promocao = jogo.Promocoes.FirstOrDefault(p => p.Ativa &&
            dataAtual >= p.DataInicio &&
            dataAtual <= p.DataFim);


        var precoFinal = jogo.Preco;

        if (promocao != null)
            precoFinal -= jogo.Preco * promocao.PercentualDesconto / 100;

        return new JogoDto
        {

            Id = jogo.Id,
            Nome = jogo.Nome,
            PrecoOriginal = jogo.Preco,
            PrecoFinal = precoFinal,
            EmPromocao = promocao != null
        };
    }

    public async Task<IEnumerable<JogoDto>> ObterJogoAsync(CancellationToken cancellationToken)
    {
        var jogos = await _context.Jogos.Include(x => x.Promocoes).ToListAsync(cancellationToken);

        var dataAtual = DateTime.Now;

        return jogos.OrderByDescending(x => x.CreatedAt)
            .Select(x =>
            {
                var promocao = x.Promocoes.FirstOrDefault(p => p.Ativa &&
                    dataAtual >= p.DataInicio &&
                    dataAtual <= p.DataFim);


                var precoFinal = x.Preco;

                if (promocao != null)
                    precoFinal -= x.Preco * promocao.PercentualDesconto / 100;

                return new JogoDto
                {

                    Id = x.Id,
                    Nome = x.Nome,
                    PrecoOriginal = x.Preco,
                    PrecoFinal = precoFinal,
                    EmPromocao = promocao != null
                };
            });
    }
}
