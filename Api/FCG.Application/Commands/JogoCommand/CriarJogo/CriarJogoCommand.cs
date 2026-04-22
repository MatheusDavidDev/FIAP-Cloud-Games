using MediatR;

namespace FCG.Application.Commands.JogoCommand.CriarJogo;

public class CriarJogoCommand : IRequest
{
    public CriarJogoCommand(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public string Nome { get; set; }
    public decimal Preco { get; set; }
}
