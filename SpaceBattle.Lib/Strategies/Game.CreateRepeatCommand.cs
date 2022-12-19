using Hwdtech;

namespace SpaceBattle.Lib;

public class CreateRepeatCommandStrategy : IStrategy
{
    public object RunStrategy(params object[] args)
    {
        var name = (string) args[0];
        
        IUObject obj = (IUObject)args[1];

        var сommand = IoC.Resolve<ICommand>("Game.CreateCommand", name, obj);

        var repeat_сommand = IoC.Resolve<ICommand>("Game.Command.Repeat", сommand);

        var inject_command = IoC.Resolve<ICommand>("Game.Command.Inject", repeat_сommand);

        return inject_command;
    }
}
