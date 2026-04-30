using System.Text.Json.Serialization;

namespace FCG.Application.DTOs;

public class BibliotecaDto
{
    public Guid Id { get; set; }
    public Guid IdJogo { get; set; }
    public string NomeJogo { get; set; }

    [JsonIgnore]
    public DateTime DataAdd { get; set; }
    public string AdicionadoEm => DataAdd.ToString("dd/MM/yyyy");

}
