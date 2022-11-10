namespace SpaceBattle.Lib;

public class QueuePushStrategy<T>: IStrategy 
{
    public object RunStrategy(params object[] args)
    {
        IQueue<T> queue = (IQueue<T>) args[0];
        T obj = (T) args[1]; 
        return new QueuePushCommand<T>(queue, obj);
    }
}