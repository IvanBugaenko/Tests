namespace SpaceBattle.Lib;

public class QueueAdapter<T>: IQueue<T>
{
    private Queue<T> queue;

    public QueueAdapter(Queue<T> queue)
    {
        this.queue = queue;
    }

    T IQueue<T>.Pop()
    {
        return queue.Dequeue();
    }

    void IQueue<T>.Push(T obj)
    {
        queue.Enqueue(obj);
    }
}