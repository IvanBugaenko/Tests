namespace SpaceBattle.Lib;

public class StopMoveCommand: ICommand
{
    private IEndable obj;
    public StopMoveCommand(IEndable obj)
    {
        this.obj = obj;
    }
    public void Execute()
    {        
        obj.Properties.ToList().ForEach(o => IoC.Resolve<ICommand>("Game.Commands.RemoveProperty", obj.Target, o).Execute());

        IoC.Resolve<IInjectable>("Game.Commands.GetProperty", obj.Target, "Moving").Inject(IoC.Resolve<ICommand>("Game.Commands.EmptyCommand"));
    }
}
