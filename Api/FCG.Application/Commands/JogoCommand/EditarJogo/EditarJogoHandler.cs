using MediatR;

namespace FCG.Application.Commands.JogoCommand.EditarJogo
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
