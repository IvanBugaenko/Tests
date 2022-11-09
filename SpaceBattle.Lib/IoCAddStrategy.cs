namespace SpaceBattle.Lib;

public class IoCAddStrategy: IStrategy
{
    private IDictionary<string, IStrategy> Dict;

    public IoCAddStrategy(IDictionary<string, IStrategy> Dict)
    {
        this.Dict = Dict;
    }

    public object Execute(params object[] args) 
    {
        string key = (string) args[0];
        IStrategy strategy = (IStrategy) args[1];
        return new IoCAddCommand(this.Dict, key, strategy);
    }
}