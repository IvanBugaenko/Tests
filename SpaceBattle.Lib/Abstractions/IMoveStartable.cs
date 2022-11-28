namespace SpaceBattle.Lib;

// public interface IStartable
// {
//     IUObject Target
//     {
//         get;
//     }
//     IDictionary<string, object> Properties
//     {
//         get;
//     }
// }

public interface IMoveStartable
{
    IUObject Target
    {
        get;
    }
    Vector Speed
    {
        get;
    }
}
