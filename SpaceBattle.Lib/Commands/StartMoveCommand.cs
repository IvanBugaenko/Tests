namespace SpaceBattle.Lib;

// class StartCommand: ICommand
// {
//     private IStartable obj;
//     public StartCommand(IStartable obj)
//     {
//         this.obj = obj;
//     }  

//     public void Execute()
//     {
//         obj.Properties.ToList().ForEach(x => IoC.Resolve<ICommand>("Game.OperationsSetProperty", obj.Target, x.Key, x.Value).Execute());
//         ICommand cmd = IoC.Resolve<ICommand>("Game.Movement", obj.Target);
//         IoC.Resolve<ICommand>("Game.Queue.Push", IoC.Resolve<Queue<ICommand>>("Game.Queue"), cmd).Execute();
//     }
// }

public class StartMoveCommand: ICommand
{
    private IStartable obj;
    public StartMoveCommand(IStartable obj)
    {
        this.obj = obj;
    }  

    public void Execute()
    {
        // IoC.Resolve<ICommand>("Game.Commands.SetProperty", obj.Target, "Speed", obj.Speed).Execute();

        obj.Properties.ToList().ForEach(o => IoC.Resolve<ICommand>("Game.Commands.SetProperty", obj.Target, o.Key, o.Value).Execute());

        ICommand cmd = IoC.Resolve<ICommand>("Game.Operations.Moving", obj.Target);
        
        IoC.Resolve<ICommand>("Game.Queue.Push", IoC.Resolve<Queue<ICommand>>("Game.Queue"), cmd).Execute();
    }
}
