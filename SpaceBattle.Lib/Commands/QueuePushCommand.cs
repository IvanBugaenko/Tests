namespace SpaceBattle.Lib;

public class QueuePushCommand<T>: ICommand
{
    private IQueue<T> queue;
    private T obj;

    public QueuePushCommand(IQueue<T> queue, T obj)
    {
        this.queue = queue;
        this.obj = obj;
    }

    public void Execute()
    {
        queue.Push(obj);
    }
}