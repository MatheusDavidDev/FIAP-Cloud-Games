using MediatR;

namespace FCG.Application.Commands.JogoCommands.CadastrarJogo;

public class CadastrarJogoCommand : IRequest
{
    public CadastrarJogoCommand(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public string Nome { get; set; }
    public decimal Preco { get; set; }
}
