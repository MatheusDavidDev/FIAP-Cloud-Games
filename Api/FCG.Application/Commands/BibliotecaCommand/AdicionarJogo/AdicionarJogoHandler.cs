using MediatR;

namespace FCG.Application.Commands.BibliotecaCommand.AdicionarJogo;

public class AdicionarJogoHandler : IRequestHandler<AdicionarJogoCommand>
{
    public AdicionarJogoHandler()
    {
        
    }

    public Task Handle(AdicionarJogoCommand request, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }
}
