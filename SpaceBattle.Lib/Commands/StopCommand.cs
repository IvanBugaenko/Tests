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
        IoC.Resolve<ICommand>("Game.Operations.StopMoving", obj.Target, obj.Move).Execute();
    }
}
