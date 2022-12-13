using Hwdtech.Ioc;
using Hwdtech;

using Moq;

namespace SpaceBattle.Lib.Test;

public class SolutionTreeTests
{
    [Fact]
    public void SuccesfulMovingRunStrategy()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();

        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

        var mockStrategyReturnsDict = new Mock<IStrategy>();
        mockStrategyReturnsDict.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(new Dictionary<int, object>());

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.GetSolutionTree", (object[] args) => mockStrategyReturnsDict.Object.RunStrategy(args)).Execute();

        var path = @"C:\Users\bugae\Tests\SpaceBattle.Lib.Test\file.txt";

        var solutiontree = new SolutionTree();

        solutiontree.BuildTree(path);

        Assert.True(IoC.Resolve<IDictionary<int, object>>("Game.GetSolutionTree").ContainsKey(1));
    }
}
