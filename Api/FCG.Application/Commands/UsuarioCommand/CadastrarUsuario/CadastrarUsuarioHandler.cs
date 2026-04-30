using FCG.Application.Interfaces.Security;
using FCG.Core.UnitOfWork;
using FCG.Domain.Entities;
using FCG.Domain.Enums;
using MediatR;

namespace FCG.Application.Commands.UsuarioCommand.CadastrarUsuario;

public class CadastrarUsuarioHandler : IRequestHandler<CadastrarUsuarioCommand, Guid>
{
    private readonly IHashSenha _hashSenha;
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarUsuarioHandler(IHashSenha hashSenha, IUnitOfWork unitOfWork)
    {
        _hashSenha = hashSenha;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuarioRepository = _unitOfWork.GetRepository<Usuario>();

        var usuarioExistente = await usuarioRepository.GetByAsync(
            predicate:u => u.Email == request.Email,
            cancellationToken: cancellationToken);

        if (usuarioExistente != null)
        {
            throw new Exception("Email já cadastrado.");
        }

        var usuario = new Usuario(
            request.Nome, 
            request.Email,
            _hashSenha.GerarHash(request.Senha), 
            TipoUsuario.Admin);
        
        await usuarioRepository.AddAsync(usuario, cancellationToken);

        await _unitOfWork.SaveChanges();

        return usuario.Id;
    }

}
