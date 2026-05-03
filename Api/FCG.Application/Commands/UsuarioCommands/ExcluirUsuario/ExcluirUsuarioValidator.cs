using FluentValidation;

namespace FCG.Application.Commands.UsuarioCommands.ExcluirUsuario
{
    public class ExcluirUsuarioValidator : AbstractValidator<ExcluirUsuarioCommand>
    {
        public ExcluirUsuarioValidator()
        {
            RuleFor(x => x.IdUsuario)
                .NotEmpty().WithMessage("O Id do usuário é obrigatório.")
                .Must(id => id != Guid.Empty).WithMessage("O Id do usuário não pode ser vazio.");
        }
    }
}
