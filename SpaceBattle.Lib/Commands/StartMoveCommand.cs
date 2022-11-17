namespace SpaceBattle.Lib;

public class StartMoveCommand: ICommand
{
    IMoveStartable order;

    public StartMoveCommand(IMoveStartable order)
    {
        this.order = order;
    }

    public void Execute()
    {
        IoC.Resolve<ICommand>("Game.Command.SetProperty", order.Target, "Speed", order.Speed).Execute();

        // IMovable move_obj = IoC.Resolve<IMovable>("CreateAdapter", typeof(MovableAdapter), order.Target);

        ICommand cmd = IoC.Resolve<ICommand>("Game.Move", order.Target);

        // IoC.Resolve<ICommand>("Game.Command.SetProperty", order.Target, "Move", cmd).Execute();

        IoC.Resolve<ICommand>("Queue.Push", IoC.Resolve<IQueue<ICommand>>("Game.Queue"), cmd).Execute();
    }
}