using FCG.Core.Models;

namespace FCG.Domain.Entities;

public class Jogo : BaseEntity
{
    public Jogo(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public ICollection<JogoBiblioteca> JogoBiblioteca { get; private set; }
    public ICollection<Promocao> Promocoes { get; private set; }

    public decimal CalcularDesconto(Promocao promocao)
    {
        var dataAtual = DateTime.Now;

        if (promocao == null)
            return Preco;

        if (!promocao.Ativa ||
            dataAtual < promocao.DataInicio ||
            dataAtual > promocao.DataFim)
        {
            return Preco;
        }

        return Preco - (Preco * promocao.PercentualDesconto / 100);
    }
}


