using Moq;

namespace SpaceBattle.Lib.Test;

public class StartMoveCommandTests
{
    public StartMoveCommandTests()
    {
        var mockStrategy = new Mock<IStrategy>();
        mockStrategy.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(It.IsAny<object>());

        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.SetProperty", mockStrategy.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Operations.StartMoving", mockStrategy.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue.Push", mockStrategy.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue", mockStrategy.Object).Execute();
}

    [Fact]
    public void NormTest()
    {
        
    }
}