namespace SpaceBattle.Lib;

public class IoCAddCommand : ICommand
{
    private IDictionary<string, IStrategy> Dict;
    private string key;
    private IStrategy strategy;

    public IoCAddCommand(IDictionary<string, IStrategy> Dict, string key, IStrategy strategy)
    {
        this.Dict = Dict;
        this.key = key;
        this.strategy = strategy;
    }

    public void Execute()
    {
        this.Dict[this.key] = this.strategy;
    }
}
