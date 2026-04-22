using MediatR;

namespace FCG.Application.Commands.JogoCommand.EditarJogo;

public class EditarJogoCommand : IRequest
{
    public EditarJogoCommand(Guid idJogo, string nome, decimal preco)
    {
        IdJogo = idJogo;
        Nome = nome;
        Preco = preco;
    }

    public Guid IdJogo { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}
