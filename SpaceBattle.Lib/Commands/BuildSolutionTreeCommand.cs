using Hwdtech;

namespace SpaceBattle.Lib;

public class BuildSolutionTreeCommand : ICommand
{
    private string path;

    public BuildSolutionTreeCommand(string path)
    {
        this.path = path;
    }
    public void Execute()
    {
        IoC.Resolve<ISolutionTree>("Game.BuildSolutionTree").BuildTree(path);
    }
}
