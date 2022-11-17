namespace SpaceBattle.Lib;

public class CreateRepeatCommand : IStrategy
{
    public object RunStrategy(params object[] args)
    {
        return new RepeatCommand((ICommand)args[0]);
    }

}