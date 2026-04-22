using FCG.Domain.Enums;
using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.CriarUsuario;

public class CriarUsuarioCommand : IRequest<Guid>
{
    public CriarUsuarioCommand(string nome, string email, string senha)
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
