using FCG.Domain.Enums;
using MediatR;

namespace FCG.Application.Commands.UsuarioCommands.EditarUsuario;

public class EditarUsuarioCommand : IRequest
{
    public EditarUsuarioCommand(Guid idUsuario, string nome, string email, TipoUsuario tipo)
    {
        IdUsuario = idUsuario;
        Nome = nome;
        Email = email;
        Tipo = tipo;
    }

    public Guid IdUsuario { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public TipoUsuario Tipo { get; set; }
}
