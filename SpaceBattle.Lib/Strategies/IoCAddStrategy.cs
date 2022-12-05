namespace SpaceBattle.Lib;

public class IoCAddStrategy : IStrategy
{
    private IDictionary<string, IStrategy> store;

    public IoCAddStrategy(IDictionary<string, IStrategy> store)
    {
        this.store = store;
    }

    public object RunStrategy(params object[] args)
    {
        string key = (string)args[0];
        IStrategy strategy = (IStrategy)args[1];
        return new IoCAddCommand(this.store, key, strategy);
    }
}
