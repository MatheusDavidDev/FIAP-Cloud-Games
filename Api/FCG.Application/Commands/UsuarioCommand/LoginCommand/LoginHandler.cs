using FCG.Application.Interfaces.Security;
using FCG.Core.UnitOfWork;
using FCG.Domain.Entities;
using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.LoginCommand;

public class LoginHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IHashSenha _hashSenha;

    public LoginHandler(IUnitOfWork unitOfWork, ITokenService tokenService, IHashSenha hashSenha)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _hashSenha = hashSenha;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var usuarioRepository = _unitOfWork.GetRepository<Usuario>();

        var usuario = await usuarioRepository.GetByAsync(predicate: u => u.Email == request.Email, cancellationToken: cancellationToken);

        if (usuario == null)
            throw new Exception("Usuário inválido");

        var senhaValida = _hashSenha.VerificarHash(request.Senha, usuario.Senha);

        if (!senhaValida)
            throw new Exception("Senha inválida");
        
        var token = _tokenService.GerarToken(usuario);

        return token;
    }
}
