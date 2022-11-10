namespace SpaceBattle.Lib;

class GetPropertyStrategy : IStrategy
{
    public object RunStrategy(params object[] args)
    {
        IUObject obj = (IUObject) args[0];
        string key = (string) args[1];
        return obj.getProperty(key);
    }
}