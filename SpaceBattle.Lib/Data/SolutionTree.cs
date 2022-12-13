using Hwdtech;

namespace SpaceBattle.Lib;

public class SolutionTree : ISolutionTree
{
    public void BuildTree(string path)
    {
        var parametrs = File.ReadAllLines(path).ToList<string>().Select(line => line.Split(" ").Select(int.Parse).ToList<int>()).ToList<List<int>>();

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
