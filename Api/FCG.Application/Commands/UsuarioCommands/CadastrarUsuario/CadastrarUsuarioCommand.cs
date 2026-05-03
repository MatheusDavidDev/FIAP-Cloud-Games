using FCG.Domain.Enums;
using MediatR;

namespace FCG.Application.Commands.UsuarioCommands.CadastrarUsuario;

public class CadastrarUsuarioCommand : IRequest<Guid>
{
    public CadastrarUsuarioCommand(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }

    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuario Tipo { get; set; }
}
