namespace SpaceBattle.Lib;

public class EmptyCommandStrategy: IStrategy
{
    private ICommand empty;
    public EmptyCommandStrategy()
    {
        empty = new EmptyCommand();
    }

    public object RunStrategy(params object[] args)
    {
        return empty;
    }
}