namespace SpaceBattle.Lib;

public class StopMoveCommand: ICommand
{
    private IMoveCommandEndable obj;
    public StopMoveCommand(IMoveCommandEndable obj)
    {
        this.obj = obj;
    }  

    public void Execute()
    {
        IoC.Resolve<ICommand>("Game.Commands.RemoveProperty", obj.Target, "Speed").Execute();
        IoC.Resolve<ICommand>("Game.Commands.SetProperty", obj.Target, "Moving", IoC.Resolve<ICommand>("Game.Commands.EmptyCommand")).Execute();
    }
}
