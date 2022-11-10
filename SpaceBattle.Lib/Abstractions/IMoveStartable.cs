namespace SpaceBattle.Lib;

public interface IMoveStartable
{
    IUObject Target
    {
        get;
    }
    int Speed
    {
        get;
    }
}
