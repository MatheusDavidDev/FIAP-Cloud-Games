using FCG.Application.Commands.BibliotecaCommand.AdicionarJogo;
using FCG.Application.Interfaces.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BibliotecaController : ControllerBase  
{
    private readonly IMediator _mediator;
    private readonly IBibliotecaQueryService _queryService;

    public BibliotecaController(IMediator mediator, IBibliotecaQueryService queryService)
    {
        _mediator = mediator;
        _queryService = queryService;
    }

    //[Authorize]
    [HttpPost("{id}")]
    public async Task<IActionResult> AdicionarJogo(Guid id, Guid idJogo)
    {
        await _mediator.Send(new AdicionarJogoCommand(id, idJogo));
        return NoContent();
    }

    [HttpGet("{idUsuario}")]
    public async Task<IActionResult> ObterBibliotecaPorIdUsuario(Guid idUsuario)
    {
        var result = await _queryService.ObterBibliotecaPorIdUsuarioAsync(idUsuario, CancellationToken.None);
        return Ok(result);
    }


}
