using MediatR;

namespace FCG.Application.Commands.JogoCommands.ExcluirJogo;

public class ExcluirJogoCommand : IRequest
{
    public ExcluirJogoCommand(Guid idJogo)
    {
        IdJogo = idJogo;
    }

    public Guid IdJogo { get; set; }
}
