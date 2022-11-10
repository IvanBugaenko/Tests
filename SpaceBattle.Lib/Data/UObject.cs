namespace SpaceBattle.Lib;

public class UObject: IUObject
{
    private IDictionary<string, object> store;
    public UObject()
    {
        this.store = new Dictionary<string, object>();
    }
    public void setProperty(string key, object value)
    {
        this.store[key] = value;
    }
    public object getProperty(string key)
    {
        return store[key];
    }
}