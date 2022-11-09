namespace SpaceBattle.Lib;

public class IoC
{
    private static IDictionary<string, IStrategy> Dict;
    
    static IoC()
    {
        Dict = new Dictionary<string, IStrategy>();
        Dict["IoC.Add"] = new IoCAddStrategy(Dict);
        // Dict["IoC.Resolve"] = 
    }
    public static T Resolve<T>(string key, params object[] args)
    {
        return (T) Dict[key].Execute(args);
        // return (T) Dict["IoC.Resolve"].Execute(key, args);
    }
}
