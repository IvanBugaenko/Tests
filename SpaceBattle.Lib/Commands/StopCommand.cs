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
        IoC.Resolve<IInjectable>("Game.Commands.GetProperty", obj.Target, "Moving").Inject(IoC.Resolve<ICommand>("Game.Commands.EmptyCommand"));
    }
}
