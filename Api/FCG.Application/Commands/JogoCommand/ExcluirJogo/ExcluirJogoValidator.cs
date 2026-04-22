using FluentValidation;

namespace FCG.Application.Commands.JogoCommand.ExcluirJogo;

public class ExcluirJogoValidator : AbstractValidator<ExcluirJogoCommand>
{
    public ExcluirJogoValidator()
    {
        RuleFor(x => x.IdJogo)
            .NotEmpty().WithMessage("O Id do jogo é obrigatório.")
            .Must(id => id != Guid.Empty).WithMessage("O Id do jogo não pode ser vazio.");
    }
}
