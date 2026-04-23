using FCG.Core.Models;
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

    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public TipoUsuario Tipo { get; private set; }
    public ICollection<JogoBiblioteca> Jogos { get; protected set; }


    public void AdicionarJogo(JogoBiblioteca jogoBiblioteca)
    {
        Jogos.Add(jogoBiblioteca);
    }

    public void Editar(string nome, TipoUsuario tipo)
    {
        Nome = nome;
        Tipo = tipo;
        SetUpdated();
    }   
}