namespace SpaceBattle.Lib;

class SetPropertyCommand: ICommand
{
    private IUObject obj;
    private string key;
    private object value;
    public SetPropertyCommand(IUObject obj, string key, object value)
    {
        this.obj = obj;
        this.key = key;
        this.value = value;
    }
    public void Execute()
    {
        obj.setProperty(key, value);
    }
}