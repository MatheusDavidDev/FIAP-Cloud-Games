namespace FCG.Application.DTOs;

public class JogoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoOriginal { get; set; }
    public string PrecoOriginalFormatado => PrecoOriginal == 0 ? "Gratuito" : PrecoOriginal.ToString("C");
    public decimal PrecoFinal { get; set; }
    public string PrecoFinalFormatado => PrecoFinal == 0 ? "Gratuito" : PrecoFinal.ToString("C");
    public bool EmPromocao { get; set; }
}
