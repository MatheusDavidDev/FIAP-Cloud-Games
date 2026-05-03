using System.Text.Json.Serialization;

namespace FCG.Application.DTOs;

public class PromocaoDto 
{
    public Guid Id { get; set; }
    public Guid IdJogo { get; set; }
    public string NomeJogo { get; set; }
    public decimal PercentualDesconto { get; set; }

    [JsonIgnore]
    public DateTime DataInicio { get; set; }
    public string DataInicioFormatada => DataInicio.ToString("dd/MM/yyyy");

    [JsonIgnore]
    public DateTime DataFim { get; set; }
    public string DataFimFormatada => DataFim.ToString("dd/MM/yyyy");

    public bool Ativa { get; set; }
}
