using FluentValidation;

namespace FCG.Application.Commands.BibliotecaCommand.AdicionarJogo;

public class AdicionarJogoValidator : AbstractValidator<AdicionarJogoCommand>   
{
    public AdicionarJogoValidator()
    {
        RuleFor(x => x.IdUsuario)
            .NotEmpty().WithMessage("O Id do usuário é obrigatório.")
            .NotEqual(Guid.Empty).WithMessage("O Id do usuário não pode ser vazio.");

        RuleFor(x => x.IdJogo)
            .NotEmpty().WithMessage("O Id do jogo é obrigatório.")
            .NotEqual(Guid.Empty).WithMessage("O Id do jogo não pode ser vazio.");
    }
}
