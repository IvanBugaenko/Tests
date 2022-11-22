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

public interface IStartable
{
    IUObject Target
    {
        get;
    }
    IDictionary<string, object> Properties
    {
        get;
    }
}
