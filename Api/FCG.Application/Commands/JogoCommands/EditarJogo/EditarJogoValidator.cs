using FluentValidation;

namespace FCG.Application.Commands.JogoCommands.EditarJogo;

public class EditarJogoValidator : AbstractValidator<EditarJogoCommand>
{
    public EditarJogoValidator()
    {
        RuleFor(x => x.IdJogo)
            .NotEmpty().WithMessage("O ID do jogo é obrigatório.");

        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do jogo é obrigatório.")
            .MinimumLength(3).WithMessage("O nome do jogo deve conter pelo menos 3 caracteres.");

        RuleFor(x => x.Preco)
            .NotEmpty().WithMessage("O valor do jogo é obrigatório.")
            .GreaterThan(0).WithMessage("O valor do jogo deve ser maior que zero.");

    }
}
