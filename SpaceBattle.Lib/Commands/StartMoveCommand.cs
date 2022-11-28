namespace SpaceBattle.Lib;

class StartCommand: ICommand
{
    private IStartable obj;
    public StartCommand(IStartable obj)
    {
        this.obj = obj;
    }  

    public void Execute()
    {
        obj.Properties;
        ICommand cmd = IoC.Resolve<ICommand>("Game.Movement", obj.Target);
        IoC.Resolve<ICommand>("Game.Queue.Push", IoC.Resolve<Queue<ICommand>>("Game.Queue"), cmd).Execute();
    }
}
