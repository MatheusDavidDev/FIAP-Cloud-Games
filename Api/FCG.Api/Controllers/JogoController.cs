using FCG.Api.Models.Jogo;
using FCG.Application.Commands.JogoCommands.CadastrarJogo;
using FCG.Application.Commands.JogoCommands.EditarJogo;
using FCG.Application.Commands.JogoCommands.ExcluirJogo;
using FCG.Application.Interfaces.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class JogoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IJogoQueryService _queryService;

    public JogoController(IMediator mediator, IJogoQueryService queryService)
    {
        _mediator = mediator;
        _queryService = queryService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Criar(CriarJogoModel model)
    {
        await _mediator.Send(new CadastrarJogoCommand(model.Nome, model.Preco));
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> JogoPorId(Guid id)
    {
        var result = await _queryService.ObterJogoPorIdAsync(id, CancellationToken.None);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ObterJogos()
    {
        var result = await _queryService.ObterJogoAsync(CancellationToken.None);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Editar(Guid id, EditarJogoModel model)
    {
        await _mediator.Send(new EditarJogoCommand(id, model.Nome, model.Preco));
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(Guid id)
    {
        await _mediator.Send(new ExcluirJogoCommand(id));
        return NoContent();
    }
}
