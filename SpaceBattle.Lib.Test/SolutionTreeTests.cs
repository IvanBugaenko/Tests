using Hwdtech.Ioc;
using Hwdtech;

using Moq;

namespace SpaceBattle.Lib.Test;

public class SolutionTreeTests
{
    public SolutionTreeTests()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();

        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
    
        var mockStrategyReturnsDict = new Mock<IStrategy>();
        mockStrategyReturnsDict.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(new Dictionary<int, object>());

        var mockISolutionTree = new Mock<ISolutionTree>();

        var mockStrategyReturnsBuilder = new Mock<IStrategy>();
        mockStrategyReturnsBuilder.Setup(x => x.RunStrategy()).Returns(new );

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.GetSolutionTree", (object[] args) => mockStrategyReturnsDict.Object.RunStrategy(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.GetSolutionTree", (object[] args) => mockStrategyReturnsDict.Object.RunStrategy(args)).Execute();
    }

    [Fact]
    public void SuccesfulBuildSolutionTree()
    {
        var path = @"..\..\..\file.txt";

        var buildCommand = new BuildSolutionTreeCommand(path);

        buildCommand.Execute();

        Assert.True(IoC.Resolve<IDictionary<int, object>>("Game.GetSolutionTree").ContainsKey(1));
    }

    [Fact]
    public void PathThrowException()
    {
        var mockStrategyReturnsDict = new Mock<IStrategy>();
        mockStrategyReturnsDict.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(new Dictionary<int, object>());

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.GetSolutionTree", (object[] args) => mockStrategyReturnsDict.Object.RunStrategy(args)).Execute();

        var path = @"..\..\..\fie.txt";

        var solutiontree = new SolutionTree();

        Assert.Throws<Exception>(() => solutiontree.BuildTree(path));
    }
}
