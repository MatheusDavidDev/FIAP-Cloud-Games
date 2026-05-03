using MediatR;

namespace FCG.Application.Commands.JogoCommands.ExcluirJogo
{
    public class ExcluirJogoHandler : IRequestHandler<ExcluirJogoCommand>
    {
        public ExcluirJogoHandler()
        {
            
        }

        public Task Handle(ExcluirJogoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
