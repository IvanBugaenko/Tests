namespace SpaceBattle.Lib;

public interface IMoveCommandEndable
{
    ICommand Move
    {
        get;
    }
    IUObject Target
    {
        get;
    }
}