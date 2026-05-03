using FCG.Application.Commands.JogoCommands.CadastrarJogo;
using FluentValidation.TestHelper;

namespace FCG.Tests.Application.Commands.Handlers.JogoCommads.CadastrarJogo;

public class CadastrarJogoValidatorTests
{
    private readonly CadastrarJogoValidator _validator;

    public CadastrarJogoValidatorTests()
    {
        _validator = new CadastrarJogoValidator();
    }

    [Fact]
    public void Deve_Ter_Erro_Quando_Nome_For_Vazio()
    {
        // Arrange
        var command = new CadastrarJogoCommand("", 10);

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Nome)
              .WithErrorMessage("O nome do jogo é obrigatório.");

    }

}
