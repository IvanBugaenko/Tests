namespace SpaceBattle.Lib;

public class IoC
{
    private static Dictionary<string, IStrategy> Dict;
    
    static T Resolve<T>(string key, params object[] args)
    {
        return (T) Dict[key].Execute(args);
    }
}
