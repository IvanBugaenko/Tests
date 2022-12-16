using Hwdtech.Ioc;
using Hwdtech;

using Moq;

namespace SpaceBattle.Lib.Test;

public class CreateRepeatCommandStrategyTests
{
    [Fact]
    public void SuccesfulCreateRepeatCommandStrategy()
    {
        var mockIUObj = new Mock<IUObject>();

        string name = "MyName";

        var mockCommand = new Mock<ICommand>();

        var mockStrategyReturnsCommand = new Mock<IStrategy>();
        mockStrategyReturnsCommand.Setup(m => m.RunStrategy(It.IsAny<object[]>())).Returns(mockCommand.Object).Verifiable();
    
        var mockIInj = new Mock<IInjectable>();
        
        var mockStrategyReturnsIInj = new Mock<IStrategy>();
        mockStrategyReturnsIInj.Setup(m => m.RunStrategy(It.IsAny<object[]>())).Returns(mockIInj.Object).Verifiable();
        
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", name, (object[] args) => mockStrategyReturnsCommand.Object.RunStrategy(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Command.Repeat", (object[] args) => mockStrategyReturnsCommand.Object.RunStrategy(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Command.Inject", (object[] args) => mockStrategyReturnsIInj.Object.RunStrategy(args)).Execute();

        var strategy = new CreateRepeatCommandStrategy();

        strategy.RunStrategy(name, mockIUObj.Object);

        mockStrategyReturnsCommand.VerifyAll();
        mockStrategyReturnsIInj.VerifyAll();

    }
}
