using FCG.Api.Models.Usuario;
using FCG.Application.Commands.JogoCommand.ExcluirJogo;
using FCG.Application.Commands.UsuarioCommand.CriarUsuario;
using FCG.Application.Commands.UsuarioCommand.EditarUsuario;
using FCG.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarUsuarioModel model)
        {
            var result = await _mediator.Send(new CriarUsuarioCommand(model.Nome, model.Email, model.Senha));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(Guid id, EditarUsuarioModel model)
        {
            await _mediator.Send(new EditarUsuarioCommand(id, model.Nome, model.Email, TipoUsuario.Admin));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _mediator.Send(new ExcluirJogoCommand(id));
            return NoContent();
        }
    }
}
