using MediatR;

namespace FCG.Application.Commands.PromocaoCommands.CriarPromocao;

public class CriarPromocaoCommad : IRequest
{
    public CriarPromocaoCommad(Guid idJogo, decimal porcentagemDesconto, DateTime dataInicio, DateTime dataFim)
    {
        IdJogo = idJogo;
        PorcentagemDesconto = porcentagemDesconto;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }

    public Guid IdJogo { get; set; }
    public decimal PorcentagemDesconto { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}
