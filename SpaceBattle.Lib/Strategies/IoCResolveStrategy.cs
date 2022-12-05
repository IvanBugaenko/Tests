namespace SpaceBattle.Lib;

public class IoCResolveStrategy : IStrategy
{
    private IDictionary<string, IStrategy> store;
    public IoCResolveStrategy(IDictionary<string, IStrategy> store)
    {
        this.store = store;
    }
    public object RunStrategy(params object[] args)
    {
        string key = (string) args[0];
        object[] a = (object[]) args[1];
        return store[key].RunStrategy(a);
    }
}
