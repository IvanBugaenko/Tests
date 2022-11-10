namespace SpaceBattle.Lib;

public class StartMoveCommand: ICommand
{
    IMoveStartable MoveStart;

    public StartMoveCommand(IMoveStartable a)
    {
        this.MoveStart = a;
    }

    public void Execute()
    {
        // IoC.Resolve<ICommand>("Game.Command.SetProperty", MoveStart.getObject, "Speed", MoveStart.getSpeed).Execute();
    }
}