using FCG.Api.Models.Jogo;
using FCG.Application.Commands.JogoCommand.CriarJogo;
using FCG.Application.Commands.JogoCommand.EditarJogo;
using FCG.Application.Commands.JogoCommand.ExcluirJogo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JogoController : ControllerBase
{
    private readonly IMediator _mediator;

    public JogoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarJogoModel model)
    {
        await _mediator.Send(new CriarJogoCommand(model.Nome, model.Preco));
        return Ok();
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
