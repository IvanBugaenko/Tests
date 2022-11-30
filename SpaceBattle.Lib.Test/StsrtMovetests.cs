using Moq;

namespace SpaceBattle.Lib.Test;

public class StartMoveCommandTests
{
    public StartMoveCommandTests()
    {
        // var mockStrategy = new Mock<IStrategy>();
        // mockStrategy.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(It.IsAny<object>());

        var mockCommand = new Mock<ICommand>();
        mockCommand.Setup(x => x.Execute());

        var mockStrategyWithParams = new Mock<IStrategy>();
        mockStrategyWithParams.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(mockCommand.Object);

        var mockStrategyWithoutParams = new Mock<IStrategy>();
        mockStrategyWithoutParams.Setup(x => x.RunStrategy()).Returns(new Queue<ICommand>());

        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.SetProperty", mockStrategyWithParams.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Operations.StartMoving", mockStrategyWithParams.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue.Push", mockStrategyWithParams.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue", mockStrategyWithoutParams.Object).Execute();
}

    [Fact]
    public void NormTest()
    {
        var startable =  new Mock<IMoveStartable>();
        var obj = new Mock<IUObject>();

        startable.Setup(a => a.Target).Returns(obj.Object).Verifiable();
        startable.Setup(a => a.Speed).Returns(new Vector(-7, 3)).Verifiable();

        ICommand startMove = new StartMoveCommand(startable.Object);

        startMove.Execute();

        startable.VerifyAll();
    }
}