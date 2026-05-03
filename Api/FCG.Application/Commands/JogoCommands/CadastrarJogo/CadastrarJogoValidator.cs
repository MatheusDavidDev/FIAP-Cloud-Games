using FluentValidation;

namespace FCG.Application.Commands.JogoCommands.CadastrarJogo;

public class CadastrarJogoValidator : AbstractValidator<CadastrarJogoCommand>
{
    public CadastrarJogoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do jogo é obrigatório.")
            .MinimumLength(3).WithMessage("O nome do jogo deve conter pelo menos 3 caracteres.");
    }
}
