using FCG.Application.Commands.UsuarioCommand.CadastrarUsuario;
using FluentValidation.TestHelper;



namespace FCG.Tests.Application.Commands.Handlers.UsuarioCommands.CadastrarUsuario;

public class CadastrarUsuarioValidatorTests
{
    private readonly CadastrarUsuarioValidator _validator;

    public CadastrarUsuarioValidatorTests()
    {
        _validator = new CadastrarUsuarioValidator();
    }

    [Fact]
    public void Deve_Ter_Erro_Quando_Nome_For_Vazio()
    {
        // Arrange
        var command = new CadastrarUsuarioCommand("", "matheus@gmail.com", "12345678@M");

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Nome)
              .WithErrorMessage("'Nome' deve ser informado."); 

    }

    [Fact]
    public void Deve_Ter_Erro_Quando_Email_For_Vazio()
    {
        // Arrange
        var command = new CadastrarUsuarioCommand("Matheus David", "", "12345678@M");

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
              .WithErrorMessage("'Email' deve ser informado.");

    }

    [Fact]
    public void Deve_Ter_Erro_Quando_Email_Nao_For_Valido()
    {
        // Arrange
        var command = new CadastrarUsuarioCommand("Matheus David", "matheus123", "12345678@M");

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
              .WithErrorMessage("'Email' é um endereço de email inválido.");
    }

    [Fact]
    public void Deve_Ter_Erro_Quando_Senha_For_Vazio()
    {
        // Arrange
        var command = new CadastrarUsuarioCommand("Matheus David", "matheus123", "");

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Senha)
              .WithErrorMessage("'Senha' deve ser informado.");
    }

    [Fact]
    public void Deve_Ter_Erro_Quando_Senha_For_Menor_que_Oito_Caracteres()
    {
        // Arrange
        var command = new CadastrarUsuarioCommand("Matheus David", "matheus123", "1234");

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Senha)
              .WithErrorMessage("'Senha' deve ser maior ou igual a 8 caracteres. Você digitou 4 caracteres.");
    }

    [Fact]
    public void Deve_Ter_Erro_Quando_Senha_Nao_Tiver_Numeros()
    {
        // Arrange
        var command = new CadastrarUsuarioCommand("Matheus David", "matheus123", "matheusDavid@");

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Senha)
              .WithErrorMessage("'Senha' não está no formato correto.");
    }

    [Fact]
    public void Deve_Ter_Erro_Quando_Senha_Nao_Tiver_Letra_Maiuscula()
    {
        // Arrange
        var command = new CadastrarUsuarioCommand("Matheus David", "matheus123", "matheusdavid123@");

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Senha)
              .WithErrorMessage("Senha deve conter letra maiúscula");
    }

    [Fact]
    public void Deve_Ter_Erro_Quando_Senha_Nao_Tiver_Caractere_Especial()
    {
        // Arrange
        var command = new CadastrarUsuarioCommand("Matheus David", "matheus123", "matheusdavid1234");

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Senha)
              .WithErrorMessage("Senha deve conter caractere especial");
    }
}
