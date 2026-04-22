using FCG.Application.Interfaces;
using FCG.Domain.Entities;
using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.CriarUsuario;

public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioCommand, Guid>
{
    private readonly IHashSenha _hashSenha;
    //private readonly IUsuarioRepository _usuarioRepository;

    public CriarUsuarioHandler(IHashSenha hashSenha)
    {
        _hashSenha = hashSenha;
    }

    public async Task<Guid> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = new Usuario(
            request.Nome, 
            request.Email,
            _hashSenha.GerarHash(request.Senha), 
            request.Tipo);

        //criar biblioteca
        var bibilioteca = new Biblioteca(usuario.Id);


        //cripitografia 

        return usuario.Id;
    }

}
