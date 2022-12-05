using Moq;

namespace SpaceBattle.Lib.Test;

public class EmptyCommandTest
{
    [Fact]
    public void EmptyCommandExecuteDoNothing()
    {
        ICommand empty = new EmptyCommand();

        empty.Execute();
    }
}
