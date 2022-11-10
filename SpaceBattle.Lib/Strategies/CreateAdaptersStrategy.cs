namespace SpaceBattle.Lib;
using System.Reflection;

public class CreateAdapters : IStrategy //Ioc.Resolve<тип, к которому хотим прийти>("CreateAdapter", typeOf(адаптер к типу), IUObject obj)
{
    public object RunStrategy(params object[] args)
    {
        Type t = (Type) args[0];
        IUObject obj = (IUObject) args[1];
        return Activator.CreateInstance(t, obj);
    }
}