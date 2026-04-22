using FluentValidation;

namespace FCG.Application.Commands.UsuarioCommand.CriarUsuario;

public class CriarUsuarioValidator : AbstractValidator<CriarUsuarioCommand>
{
    public CriarUsuarioValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Senha)
            .NotEmpty()
            .MinimumLength(8)
            .Matches("[0-9]").WithMessage("Senha deve conter número")
            .Matches("[A-Z]").WithMessage("Senha deve conter letra maiúscula")
            .Matches("[^a-zA-Z0-9]").WithMessage("Senha deve conter caractere especial");
    }
}
