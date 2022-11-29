namespace SpaceBattle.Lib;

class StopMoveCommand: ICommand
{
    private IMoveCommandEndable obj;
    public StopMoveCommand(IMoveCommandEndable obj)
    {
        this.obj = obj;
    }  

    public void Execute()
    {
        IoC.Resolve<ICommand>("Game.Commands.RemoveProperty", obj.Target, "Speed").Execute();
        ICommand cmd = IoC.Resolve<ICommand>("Game.Operations.StopMoving", obj.Target, obj.Move);
        IoC.Resolve<ICommand>("Game.Queue.Push", IoC.Resolve<Queue<ICommand>>("Game.Queue"), cmd).Execute();
    }
}
