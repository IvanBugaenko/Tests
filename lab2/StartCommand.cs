namespace SpaceBattle.Lib;

class StartCommand: ICommand
{
    private IMoveStartable obj;
    public StartCommand(IMoveStartable obj)
    {
        this.obj = obj;
    }  

    public void Execute()
    {
        IoC.Resolve<ICommand>("Game.Operations.SetProperty", obj.Target, "Velocity", obj.Speed).Execute();
        IMovable movable = IoC.Resolve<IMovable>("Game.Adapter", obj.Target);
        ICommand cmd = IoC.Resolve<ICommand>("Game.Movement", movable);
        IoC.Resolve<ICommand>("Game.Queue.Push", IoC.Resolve<IQueue<ICommand>>("Game.Queue"), cmd).Execute();
    }
}
