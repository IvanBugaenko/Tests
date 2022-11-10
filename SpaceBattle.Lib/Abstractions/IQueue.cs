namespace SpaceBattle.Lib;

public interface IQueue<T>
{
    public void Push(T cmd);
    public T Pop();
}