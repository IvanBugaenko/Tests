using Moq;

namespace SpaceBattle.Lib.Test;

public class StartMoveCommandTests
{
    public StartMoveCommandTests()
    {
        var mockCommand = new Mock<ICommand>();
        mockCommand.Setup(x => x.Execute());

        var mockStrategyWithParams = new Mock<IStrategy>();
        mockStrategyWithParams.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(mockCommand.Object);

        var mockStrategyWithoutParams = new Mock<IStrategy>();
        mockStrategyWithoutParams.Setup(x => x.RunStrategy()).Returns(new Queue<ICommand>());
        
        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.SetProperty", mockStrategyWithParams.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Operations.Moving", mockStrategyWithParams.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue.Push", mockStrategyWithParams.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue", mockStrategyWithoutParams.Object).Execute();
}

    [Fact]
    public void NormTest()
    {
        var startable = new Mock<IStartable>();
        var obj = new Mock<IUObject>();

        startable.SetupGet(a => a.Target).Returns(obj.Object).Verifiable();
        startable.SetupGet(a => a.Properties).Returns(new Dictionary<string, object>(){{"Speed", new Vector(1, 1)}}).Verifiable();

        ICommand startMove = new StartMoveCommand(startable.Object);

        startMove.Execute();

        startable.VerifyAll();
    }

    [Fact]
    public void TargetMethodReturnsException()
    {
        var startable = new Mock<IStartable>();

        startable.SetupGet(a => a.Target).Throws<Exception>().Verifiable();
        startable.SetupGet(a => a.Properties).Returns(new Dictionary<string, object>(){{"Speed", new Vector(1, 1)}}).Verifiable();

        ICommand startMove = new StartMoveCommand(startable.Object);

        Assert.Throws<Exception>(() => startMove.Execute());

        // startable.Verify(m => m.Properties, Times.Once());
    }

    [Fact]
    public void SpeedMethodReturnsException()
    {
        var startable = new Mock<IStartable>();
        var obj = new Mock<IUObject>();

        startable.SetupGet(a => a.Target).Returns(obj.Object).Verifiable();
        startable.SetupGet(a => a.Properties).Throws<Exception>().Verifiable();

        ICommand startMove = new StartMoveCommand(startable.Object);

        Assert.Throws<Exception>(() => startMove.Execute());
    }
}