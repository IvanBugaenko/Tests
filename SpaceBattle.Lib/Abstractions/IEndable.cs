namespace SpaceBattle.Lib;

public interface IEndable
{
    IEnumerable<string> Properties
    {
        get;
    }
    IUObject Target
    {
        get;
    }
}
