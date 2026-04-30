namespace FCG.Application.DTOs;

public class JogoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string PrecoFormatado => Preco == 0 ? "Gratuito" : Preco.ToString("C");
    public bool promocao { get; set; }
}
