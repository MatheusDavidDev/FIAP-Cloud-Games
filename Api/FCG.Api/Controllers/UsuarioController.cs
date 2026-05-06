using FCG.Api.Models.Usuario;
using FCG.Application.Commands.JogoCommands.ExcluirJogo;
using FCG.Application.Commands.UsuarioCommands.CadastrarUsuario;
using FCG.Application.Commands.UsuarioCommands.EditarUsuario;
using FCG.Application.Interfaces.Queries;
using FCG.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUsuarioQueryService _queryService;

    public UsuarioController(IMediator mediator, IUsuarioQueryService queryService)
    {
        _mediator = mediator;
        _queryService = queryService;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarUsuarioModel model)
    {
        var result = await _mediator.Send(new CadastrarUsuarioCommand(model.Nome, model.Email, model.TipoUsuario, model.Senha));
        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> UsuarioPorId(Guid id)
    {
        var result = await _queryService.ObterUsuarioPorIdAsync(id, CancellationToken.None);
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> ObterUsuarios()
    {
        var result = await _queryService.ObterUsuariosAsync(CancellationToken.None);
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Editar(Guid id, EditarUsuarioModel model)
    {
        await _mediator.Send(new EditarUsuarioCommand(id, model.Nome, model.Email, TipoUsuario.Admin));
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(Guid id)
    {
        await _mediator.Send(new ExcluirJogoCommand(id));
        return NoContent();
    }
}
