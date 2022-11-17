namespace SpaceBattle.Lib;


public class OperationMoveStrategy : IStrategy
{

    public object RunStrategy(params object[] args)
    {
        IUObject uobj = (IUObject)args[0];
        IEnumerable<string> listcommands = (IEnumerable<string>)args[1];
        var listcommand = listcommands.Select(c => IoC.Resolve<ICommand>(c, uobj));

        ICommand _TAkeinMouse267e_9 = new Moving(uobj);

        ICommand repeat = IoC.Resolve<ICommand>("Create.RepeatCommand", _TAkeinMouse267e_9);
        listcommand.Append(repeat);

        ICommand macro = IoC.Resolve<ICommand>("Create.MacroCommand", listcommand);
        IoC.Resolve<ICommand>("Game.Commands.SetProperty", uobj, "ThisCommand", macro).Execute();
        return _TAkeinMouse267e_9;
    }


}