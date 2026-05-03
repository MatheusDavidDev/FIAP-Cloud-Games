using FluentValidation;

namespace FCG.Application.Commands.PromocaoCommands.CriarPromocao
{
    public class CriarPromocaoValidator : AbstractValidator<CriarPromocaoCommad>
    {
        public CriarPromocaoValidator()
        {
            RuleFor(x => x.IdJogo)
                .NotEmpty().WithMessage("O Id do jogo é obrigatório.");

            RuleFor(x => x.PorcentagemDesconto)
                .GreaterThan(0).WithMessage("A porcentagem de desconto deve ser maior que 0.")
                .LessThanOrEqualTo(100).WithMessage("A porcentagem de desconto deve ser menor ou igual a 100.");

            RuleFor(x => x.DataInicio)
                .LessThan(x => x.DataFim).WithMessage("A data de início deve ser anterior à data de fim.");

            RuleFor(x => x.DataFim)
                .GreaterThan(x => x.DataInicio).WithMessage("A data de fim deve ser posterior à data de início.");
        }
    }
}
