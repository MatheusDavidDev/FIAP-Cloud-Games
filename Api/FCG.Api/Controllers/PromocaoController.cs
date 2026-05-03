using FCG.Api.Models.Promocao;
using FCG.Application.Commands.PromocaoCommands.CriarPromocao;
using FCG.Application.Interfaces.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PromocaoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPromocaoQueryService _queryService;

    public PromocaoController(IMediator mediator, IPromocaoQueryService queryService)
    {
        _mediator = mediator;
        _queryService = queryService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarPromocao(CriarPromocaoModel model)
    {
        await _mediator.Send(new CriarPromocaoCommad(model.IdJogo, model.PorcentagemDesconto, model.DataInicio, model.DataFim));

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> ObterPromocoes()
    {
        var result = await _queryService.ObterPromocoesAsync(CancellationToken.None);

        return Ok(result);
    }

}
