using MediatR;

namespace FCG.Application.Commands.JogoCommands.EditarJogo
{
    public class EditarJogoHandler : IRequestHandler<EditarJogoCommand>
    {
        public EditarJogoHandler()
        {
            
        }

        public Task Handle(EditarJogoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
