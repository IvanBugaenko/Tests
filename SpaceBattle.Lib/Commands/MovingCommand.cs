namespace SpaceBattle.Lib;

public class Moving : ICommand
{
    private IUObject obj;
    public Moving(IUObject obj)
    {
        this.obj = obj;
    }

    public void Execute()
    {
        ((ICommand)obj.getProperty("ThisCommand")).Execute();
    }
}