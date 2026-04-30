using FCG.Application.Commands.UsuarioCommand.CadastrarUsuario;
using FCG.Application.Interfaces.Security;
using FCG.Core.Repository;
using FCG.Core.UnitOfWork;
using FCG.Domain.Entities;
using FCG.Domain.Enums;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System.Linq.Expressions;

namespace FCG.Tests.Application.Commands.Handlers;

public class CadastrarUsuarioHandlerTests
{

    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IHashSenha> _hashSenhaMock; 
    private readonly Mock<IRepository<Usuario>> _repositoryMock;
    private readonly CancellationToken _cancellationToken;

    public CadastrarUsuarioHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _hashSenhaMock = new Mock<IHashSenha>();
        _repositoryMock = new Mock<IRepository<Usuario>>();
        _cancellationToken = CancellationToken.None;
    }

    [Fact]
    public async Task Deve_Criar_Jogo_Com_Sucesso()
    {
        // Arrange
        var IHashSenhaMock = new Mock<IHashSenha>();

        _unitOfWorkMock.Setup(x => x.GetRepository<Usuario>()).Returns(_repositoryMock.Object);

        _unitOfWorkMock.Setup(x => x.SaveChanges()).ReturnsAsync(1);

        var handler = new CadastrarUsuarioHandler(_hashSenhaMock.Object, _unitOfWorkMock.Object);
        var command = new CadastrarUsuarioCommand("Matheus David", "matheus@gmail.com","12345678@M");

        // Act
        await handler.Handle(command, _cancellationToken);

        // Assert
        _unitOfWorkMock.Verify(x => x.GetRepository<Usuario>(), Times.Once);

        _repositoryMock.Verify(x => x.AddAsync(It.IsAny<Usuario>(), _cancellationToken),
            Times.Once);

        _unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public async Task Nao_Deve_Criar_Usuario_Com_Email_Duplicado()
    {
        // Arrange
        var email = "matheus@gmail.com";
        var command = new CadastrarUsuarioCommand("Matheus David", email, "12345678@M");
        var usuarioExistente = new Usuario("Matheus David", email, "hash", TipoUsuario.Admin);

        _repositoryMock.Setup(x => x.GetByAsync(
            It.IsAny<Expression<Func<Usuario, bool>>>(), 
            It.IsAny<Func<IQueryable<Usuario>, IIncludableQueryable<Usuario, object>>>(), _cancellationToken)).ReturnsAsync(usuarioExistente);

        _unitOfWorkMock.Setup(x => x.GetRepository<Usuario>()).Returns(_repositoryMock.Object);

        var handler = new CadastrarUsuarioHandler(_hashSenhaMock.Object, _unitOfWorkMock.Object);

        // Act
        Func<Task> act = async () => await handler.Handle(command, _cancellationToken);

        // Assert
        await handler.Invoking(x => x.Handle(command, _cancellationToken)).Should().ThrowAsync<Exception>()
         .WithMessage("Email já cadastrado.");

        _repositoryMock.Verify(x => x.AddAsync(It.IsAny<Usuario>(), _cancellationToken), Times.Never);
        _unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Never);
    }

}
