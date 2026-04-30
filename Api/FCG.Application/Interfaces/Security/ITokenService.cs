using FCG.Domain.Entities;

namespace FCG.Application.Interfaces.Security;

public interface ITokenService
{
    string GerarToken(Usuario usuario);

}
