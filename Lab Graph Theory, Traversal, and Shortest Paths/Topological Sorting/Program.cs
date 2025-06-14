
int n = int.Parse(Console.ReadLine());

Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
Dictionary<string, int> dependencies = new Dictionary<string, int>();
List<string> result = new List<string>();

ReadGraph(n);
ExtractDependencies();

while (dependencies.Count > 0)
{
    string nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;

    if (nodeToRemove == null)
    {
        Console.WriteLine("Invalid topological sorting");
        return;
    }

    dependencies.Remove(nodeToRemove);
    result.Add(nodeToRemove);

    foreach (var child in graph[nodeToRemove])
    {
        dependencies[child]--;
    }
}

Console.WriteLine($"Topological sorting: {string.Join(", ", result)}");

void ExtractDependencies()
{
    foreach (var kvp in graph)
    {
        string node = kvp.Key;
        List<string> children = kvp.Value;

        if (!dependencies.ContainsKey(node))
        {
            dependencies[node] = 0;
        }

        foreach (var child in children)
        {
            if (!dependencies.ContainsKey(child))
            {
                dependencies[child] = 1;
            }
            else
            {
                dependencies[child]++;
            }
        }
    }
}

void ReadGraph(int n)
{
    for (int i = 0; i < n; i++)
    {
        string[] input = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Trim())
                    .ToArray();

        string node = input[0];

        if (input.Length > 1)
        {
            List<string> children = input[1].Split(", ").ToList();
            graph[node] = children;
        }
        else
        {
            graph[node] = new List<string>();
        }
    }
}