namespace SpaceBattle.Lib;

public interface IQueue<T>
{
    public void Push(T obj);
    public T Pop();
}