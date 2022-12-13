using Hwdtech;

namespace SpaceBattle.Lib;

public class SolutionTree : ISolutionTree
{
    public void BuildTree(string path)
    {
        var parametrs = File.ReadAllLines(path).ToList().Select(line => line.Split(" ").Select(int.Parse).ToList()).ToList();

        var tree = IoC.Resolve<IDictionary<int, object>>("Game.GetSolutionTree");

        parametrs.ForEach(list =>
        {
            var temp = tree;
            list.ForEach(num => 
            {
                temp.TryAdd(num, new Dictionary<int, object>()); 
                temp = (Dictionary<int, object>) temp[num];
            });
        });
    }
}
