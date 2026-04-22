using MediatR;

namespace FCG.Application.Commands.JogoCommand.CriarJogo;

public class CriarJogoHandler : IRequestHandler<CriarJogoCommand>
{
    public CriarJogoHandler()
    {
        
    }

    public Task Handle(CriarJogoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
