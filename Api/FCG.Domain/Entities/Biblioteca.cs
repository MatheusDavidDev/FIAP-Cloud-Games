namespace FCG.Domain.Entities;

public class Biblioteca : BaseEntity
{
    public Biblioteca(Guid usuarioId)
    {
        IdUsuario = usuarioId;
        Jogos = new List<JogoBiblioteca>();
    }

    public Guid IdUsuario { get; set; }
    public List<JogoBiblioteca> Jogos { get; private set; }

    public void AdicionarJogo(Guid idJogo)
    {
        if (!Jogos.Any(x => x.IdJogo == idJogo))
        Jogos.Add(new JogoBiblioteca(idJogo));
    }

}

public class JogoBiblioteca
{
    public JogoBiblioteca(Guid idJogo)
    {
        IdJogo = idJogo;
        AddedAt = DateTime.UtcNow;
    }

    public Guid IdJogo { get; set; }
    public DateTime AddedAt { get; set; }
}
