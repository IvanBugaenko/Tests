namespace SpaceBattle.Lib;

public class GetQueueStrategy<T> : IStrategy
{
    private IQueue<T> queue;
    public GetQueueStrategy(IQueue<T> queue)
    {
        this.queue = queue;
    }

    public object RunStrategy(params object[] args)
    {
        return queue;
    }
}