using FCG.Application.Commands.UsuarioCommand.AdicionarJogo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BibliotecaController : ControllerBase  
{
    private readonly IMediator _mediator;

    public BibliotecaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AdicionarJogo(Guid id, Guid idJogo)
    {
        await _mediator.Send(new AdicionarJogoCommand(id, idJogo));
        return NoContent();
    }
}
