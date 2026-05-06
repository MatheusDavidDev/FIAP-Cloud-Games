using FCG.Application.Commands.JogoCommands.CadastrarJogo;
using FCG.Core.Repository;
using FCG.Core.UnitOfWork;
using FCG.Domain.Entities;
using Moq;

namespace FCG.Tests.Application.Commands.Handlers.JogoCommads.CadastrarJogo;

public class CadastrarJogoHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IRepository<Jogo>> _repositoryMock;

    public CadastrarJogoHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _repositoryMock = new Mock<IRepository<Jogo>>();
        var cancellationToken = CancellationToken.None;
    }

    [Fact]
    public async Task Deve_Criar_Jogo_Com_Sucesso()
    {
        // Arrange

        _unitOfWorkMock.Setup(x => x.GetRepository<Jogo>()).Returns(_repositoryMock.Object);

        _unitOfWorkMock.Setup(x => x.SaveChanges()).ReturnsAsync(1);

        var handler = new CadastrarJogoHandler(_unitOfWorkMock.Object);

        var command = new CadastrarJogoCommand("GTA", 50);

        var cancellationToken = CancellationToken.None;

        // Act
        await handler.Handle(command, cancellationToken);

        // Assert
        _unitOfWorkMock.Verify(x => x.GetRepository<Jogo>(), Times.Once);

        _repositoryMock.Verify(x =>  x.AddAsync(It.IsAny<Jogo>(), cancellationToken),
            Times.Once);

        _unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
    }
}
