using Moq;

namespace SpaceBattle.Lib.Test;

public class MovingStrategyTests
{
    [Fact]
    public void NormTest()
    {

        var mockCommand = new Mock<ICommand>();

        var mockListCommand = new Mock<IEnumerable<ICommand>>();

        var mockStrategyReturnCommand = new Mock<IStrategy>();
        mockStrategyReturnCommand.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(mockCommand.Object).Verifiable();

        var mockStrategyReturnsIEnum = new Mock<IStrategy>();
        mockStrategyReturnsIEnum.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(mockListCommand.Object).Verifiable();
        
        IoC.Resolve<ICommand>("IoC.Add", "Game.CreateMove", mockStrategyReturnsIEnum.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Command.Inject", mockStrategyReturnCommand.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Command.Macro", mockStrategyReturnCommand.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Add", "Game.Command.Repeat", mockStrategyReturnCommand.Object).Execute();
        
        var obj = new Mock<IUObject>();

        MovingStrategy strategy = new MovingStrategy();

        strategy.RunStrategy(obj.Object);

        mockStrategyReturnCommand.VerifyAll();
        mockStrategyReturnsIEnum.VerifyAll();

        
    }

    
}