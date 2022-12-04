using Moq;

namespace SpaceBattle.Lib.Test;

public class StopMoveCommandTests
{
    public StopMoveCommandTests()
    {
        var mockCommand = new Mock<ICommand>();
        mockCommand.Setup(x => x.Execute());

        var mockInject = new Mock<IInjectable>();
        mockInject.Setup(x => x.Inject(It.IsAny<ICommand>()));

        var mockStrategyReturnCommand = new Mock<IStrategy>();
        mockStrategyReturnCommand.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(mockCommand.Object);

        var mockStrategyReturnEmpty = new Mock<IStrategy>();
        mockStrategyReturnEmpty.Setup(x => x.RunStrategy()).Returns(new EmptyCommand());

        var mockStrategyReturnIInjectable = new Mock<IStrategy>();
        mockStrategyReturnIInjectable.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(mockInject.Object);

        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.RemoveProperty", mockStrategyReturnCommand.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.EmptyCommand", mockStrategyReturnEmpty.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.GetProperty", mockStrategyReturnIInjectable.Object).Execute();
}

    [Fact]
    public void NormTest()
    {
        var stopable = new Mock<IEndable>();
        var obj = new Mock<IUObject>();

        stopable.SetupGet(a => a.Target).Returns(obj.Object).Verifiable();
        stopable.SetupGet(a => a.Properties).Returns(new List<string>(){"Speed"}).Verifiable();

        ICommand stopMove = new StopMoveCommand(stopable.Object);

        stopMove.Execute();

        stopable.VerifyAll();
    }

    [Fact]
    public void TargetMethodReturnsException()
    {
        var stopable = new Mock<IEndable>();

        stopable.SetupGet(a => a.Target).Throws<Exception>().Verifiable();
        stopable.SetupGet(a => a.Properties).Returns(new List<string>(){"Speed"}).Verifiable();

        ICommand stopMove = new StopMoveCommand(stopable.Object);

        Assert.Throws<Exception>(() => stopMove.Execute());

        // startable.Verify(m => m.Properties, Times.Once());
    }

    [Fact]
    public void SpeedMethodReturnsException()
    {
        var stopable = new Mock<IEndable>();
        var obj = new Mock<IUObject>();

        stopable.SetupGet(a => a.Target).Returns(obj.Object).Verifiable();
        stopable.SetupGet(a => a.Properties).Throws<Exception>().Verifiable();

        ICommand startMove = new StopMoveCommand(stopable.Object);

        Assert.Throws<Exception>(() => startMove.Execute());
    }

    
}