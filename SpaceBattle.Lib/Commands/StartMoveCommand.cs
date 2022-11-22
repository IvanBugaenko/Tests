namespace SpaceBattle.Lib;
public class StartMoveCommand : ICommand
{
    IMoveStartable startable;
    IEnumerable<string> listcomands;

    public StartMoveCommand(IMoveStartable startable, IEnumerable<string> listcomands)
    {
        this.startable = startable;
        this.listcomands = listcomands;
    }

    public void Execute()
    {
        IoC.Resolve<ICommand>("Game.Commands.SetProperty", startable.Target, "Speed", startable.Speed).Execute(); // засетит нужное -- супер стратегия
        ICommand cmd  = IoC.Resolve<ICommand>("Game.Commands.Move", startable.Target, listcomands);
        //добавлять репитнутую здесь
        IoC.Resolve<ICommand>("Game.Queue.Push", IoC.Resolve<IQueue<ICommand>>("Game.Queue"), cmd).Execute();
    }

}
