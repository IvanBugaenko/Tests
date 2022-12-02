// using Moq;

// namespace SpaceBattle.Lib.Test;

// public class StopMoveCommandTests
// {
//     public StopMoveCommandTests()
//     {
//         var mockCommand = new Mock<ICommand>();
//         mockCommand.Setup(x => x.Execute());

//         var mockStrategyWithParams = new Mock<IStrategy>();
//         mockStrategyWithParams.Setup(x => x.RunStrategy(It.IsAny<object[]>())).Returns(mockCommand.Object);

//         var mockStrategyWithoutParams = new Mock<IStrategy>();
//         mockStrategyWithoutParams.Setup(x => x.RunStrategy()).Returns(mockCommand.Object);

//         IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.SetProperty", mockStrategyWithParams.Object).Execute();
//         IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.RemoveProperty", mockStrategyWithParams.Object).Execute();
//         IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.EmptyCommand", mockStrategyWithoutParams.Object).Execute();
// }

//     [Fact]
//     public void NormTest()
//     {
//         var stopable = new Mock<IMoveCommandEndable>();
//         var obj = new Mock<IUObject>();

//         stopable.SetupGet(a => a.Target).Returns(obj.Object).Verifiable();

//         ICommand stopMove = new StopMoveCommand(stopable.Object);

//         stopMove.Execute();

//         stopable.VerifyAll();
//     }

//     [Fact]
//     public void TargetMethodReturnsException()
//     {
//         var stopable = new Mock<IMoveCommandEndable>();

//         stopable.SetupGet(a => a.Target).Throws<Exception>().Verifiable();

//         ICommand stopMove = new StopMoveCommand(stopable.Object);

//         Assert.Throws<Exception>(() => stopMove.Execute());
//     }
// }