namespace SpaceBattle.Lib;

public class SetPropertyStrategy : IStrategy
{
    public object RunStrategy(params object[] args)
    {
        IUObject obj = (IUObject) args[0];
        string key = (string) args[1];
        object value = (object) args[2];
        return new SetPropertyCommand(obj, key, value);
    }
}