using Hwdtech;

namespace SpaceBattle.Lib;

public class DetectCollisionCommand: ICommand
{
    private IUObject obj1, obj2;
    public DetectCollisionCommand(IUObject obj1, IUObject obj2)
    {
        this.obj1 = obj1;
        this.obj2 = obj2;
    }

    public void Execute()
    {
        var tree = IoC.Resolve<IDictionary<int, object>>("Game.GetSolutionTree");

        var speed1 = IoC.Resolve<Vector>("Game.Commands.GetProperty", obj1, "Speed");
        var speed2 = IoC.Resolve<Vector>("Game.Commands.GetProperty", obj2, "Speed");

        var pos1 = IoC.Resolve<Vector>("Game.Commands.GetProperty", obj1, "Position");
        var pos2 = IoC.Resolve<Vector>("Game.Commands.GetProperty", obj2, "Position");

        var parametrs = new List<int>()
        {
            pos1[0] - pos1[1], pos2[0] - pos2[1], speed1[0] - speed1[1], speed2[0] - speed2[1]
        };

        parametrs.ForEach(num => tree = (IDictionary<int, object>) tree[num]);

        if (tree.Keys.First() != 0) IoC.Resolve<ICommand>("Game.Collision", obj1, obj2).Execute();
    }
}
