using MediatR;

namespace FCG.Application.Commands.UsuarioCommands.Login;

public class LoginCommand : IRequest<string>
{
    public LoginCommand(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }

    public string Email { get; set; }
    public string Senha { get; set; }
}
