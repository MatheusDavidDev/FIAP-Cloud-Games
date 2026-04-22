namespace FCG.Domain.Entities;

public class Jogo : BaseEntity
{
    public Jogo(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public string Nome { get; set; }
    public decimal Preco { get; set; }
}
