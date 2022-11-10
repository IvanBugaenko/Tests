namespace SpaceBattle.Lib;

public class MovableAdapter : IMovable
{
    private IUObject obj;
    public MovableAdapter(IUObject obj)
    {
        this.obj = obj;
    }

    public Vector Speed 
    {
        get
        {
            return (Vector) obj.getProperty("Speed");
        }
    }

    public Vector Pos 
    { 
        get
        {
            return (Vector) obj.getProperty("Position");
        }
        set 
        {
            obj.setProperty("Position", value);
        } 
    }
}
