using FCG.Domain.Enums;

namespace FCG.Domain.Entities;

public class Usuario : BaseEntity
{
    public Usuario(string nome, string email, string senha, TipoUsuario tipo)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        Tipo = tipo;
    }

    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuario Tipo { get; set; }
}
