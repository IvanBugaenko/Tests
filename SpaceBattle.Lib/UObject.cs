namespace SpaceBattle.Lib;

public class UObject: IUObject
{
    private IDictionary<string, object> Dict;
    public UObject()
    {
        this.Dict = new Dictionary<string, object>();
    }
    public void setProperty(string key, object value)
    {
        this.Dict[key] = value;
    }
    public object getProperty(string key)
    {
        return Dict[key];
    }
}