namespace SpaceBattle.Lib;

public class MoveStrategy : IStrategy
{

    public object RunStrategy(params object[] args)
    {

        IUObject uObject = (IUObject)args[0];
        IMovable movable = IoC.Resolve<IMovable>("Game.Adapter", uObject, typeof(MovableAdapter));
        ICommand cmd = new MoveCommand(movable);
        return cmd;
    }
}