using FluentValidation;

namespace FCG.Application.Commands.JogoCommand.CriarJogo;

public class CriarJogoValidator : AbstractValidator<CriarJogoCommand>
{
    public CriarJogoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do jogo é obrigatório.")
            .MinimumLength(3).WithMessage("O nome do jogo deve conter pelo menos 3 caracteres.");
    }
}
