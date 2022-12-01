namespace SpaceBattle.Lib;

public class StartMovingStrategy : IStrategy
{
    public object RunStrategy(params object[] args)
    {
        IUObject obj = (IUObject) args[0];

        IEnumerable<ICommand> list_command = new List<ICommand>();

        IoC.Resolve<IEnumerable<string>>("Game.Config").ToList().ForEach(str => list_command.Append(IoC.Resolve<ICommand>(str)));

        ICommand inject_command = IoC.Resolve<ICommand>("");
        
        IoC.Resolve<ICommand>("Game.Commands.SetProperty", obj, inject_command).Execute();

        return inject_command;
    }
}