using Hwdtech;

namespace SpaceBattle.Lib;

public class BuildSolutionTreeStrategy : IStrategy
{
    public object RunStrategy(params object[] args)
    {
        string path = (string) args[0];
        return new BuildSolutionTreeCommand(path);
    }
}
