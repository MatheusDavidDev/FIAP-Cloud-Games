using FCG.Application.DTOs;
using FCG.Application.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infra.Queries;

public class UsuarioQueryService : IUsuarioQueryService
{
    private readonly FcgDbContext _context;

    public UsuarioQueryService(FcgDbContext context)
    {
        _context = context;
    }

    public async Task<UsuarioDto> ObterUsuarioPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (usuario == null)
            return null;
        

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }

    public async Task<IEnumerable<UsuarioDto>> ObterUsuariosAsync(CancellationToken cancellationToken)
    {
        var usuarios = await _context.Usuarios.ToListAsync(cancellationToken);
        return usuarios.OrderByDescending(x => x.CreatedAt)
            .Select(x => new UsuarioDto
        {
            Id = x.Id,
            Nome = x.Nome,
            Email = x.Email
        });
    }
}
