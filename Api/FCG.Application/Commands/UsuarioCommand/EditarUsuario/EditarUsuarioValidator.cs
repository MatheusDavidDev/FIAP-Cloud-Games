using FluentValidation;

namespace FCG.Application.Commands.UsuarioCommand.EditarUsuario;

public class EditarUsuarioValidator : AbstractValidator<EditarUsuarioCommand>
{
    public EditarUsuarioValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve conter pelo menos 3 caracteres.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email deve ser válido.");
    }
}
