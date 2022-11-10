namespace SpaceBattle.Lib;

public class IoC
{
    private static IDictionary<string, IStrategy> store; 
    
    static IoC()
    {
        store = new Dictionary<string, IStrategy>();
        store["IoC.Add"] = new IoCAddStrategy(store);
        store["IoC.Resolve"] = new IoCResolveStrategy(store);
    }
    public static T Resolve<T>(string key, params object[] args)
    {
        // return (T) store[key].RunStrategy(args);
        return (T) store["IoC.Resolve"].RunStrategy(key, args);
    }
}
