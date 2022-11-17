namespace SpaceBattle.Lib;

public class MovingCommand : ICommand
{
    IUObject obj;
    public MovingCommand(IUObject obj)
    {
        this.obj = obj;
    }

    public void Execute()
    {
        ICommand cmd = IoC.Resolve<ICommand>("UObject.GetProperty", "Move");

        ICommand MoveCMD = new MoveCommand(IoC.Resolve<IMovable>("CreateAdapter", typeof(MovableAdapter), obj));

    }
}