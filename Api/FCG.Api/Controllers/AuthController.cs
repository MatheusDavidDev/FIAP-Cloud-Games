using FCG.Api.Models.Usuario;
using FCG.Application.Commands.UsuarioCommands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var login = await _mediator.Send(new LoginCommand(model.Email, model.Senha));

        return Ok(login);
    }
}
