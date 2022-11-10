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

        IMovable move_obj = IoC.Resolve<IMovable>("CreateAdapter", typeof(MovableAdapter), order.Target);
    }
}