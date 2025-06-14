
int n = int.Parse(Console.ReadLine());

Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
Stack<string> result = new Stack<string>();
HashSet<string> visited = new HashSet<string>();
HashSet<string> cycles = new HashSet<string>();

ReadGraph(n);

foreach (var node in graph.Keys)
{
    try
    {
        DFS(node);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

Console.WriteLine($"Topological sorting: {string.Join(", ", result)}");

void DFS(string node)
{
    if (cycles.Contains(node))
    {
        throw new InvalidOperationException("The given graph is cyclic.");
    }

    if (visited.Contains(node))
    {
        return;
    }

    visited.Add(node);
    cycles.Add(node);

    foreach (var child in graph[node])
    {
        DFS(child);
    }

    result.Push(node);
    cycles.Remove(node);
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