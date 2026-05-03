using FCG.Core.Models;

namespace FCG.Domain.Entities;

public class Promocao : BaseEntity
{
    public Promocao(Guid idJogo, decimal percentualDesconto, DateTime dataInicio, DateTime dataFim)
    {
        IdJogo = idJogo;
        PercentualDesconto = percentualDesconto;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Ativa = true;
    }

    public Guid IdJogo { get; private set; }
    public Jogo Jogo { get; private set; }
    public decimal PercentualDesconto { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime DataFim { get; private set; }
    public bool Ativa { get; private set; }
}
