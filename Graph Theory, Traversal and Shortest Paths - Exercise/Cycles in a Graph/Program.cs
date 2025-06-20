Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
HashSet<string> visited = new HashSet<string>();

while (true)
{
    string command = Console.ReadLine();

    if (command == "End")
    {
        break;
    }

    string[] graphRow = command.Split("-", StringSplitOptions.RemoveEmptyEntries);

    string from = graphRow[0].Trim();
    string to = graphRow[1].Trim();

    if (!graph.ContainsKey(from))
    {
        graph[from] = new List<string>();
    }

    graph[from].Add(to);

    if (!graph.ContainsKey(to))
    {
        graph[to] = new List<string>();
    }
}

try
{
    foreach (var node in graph.Keys)
    {
        if (visited.Contains(node))
        {
            continue;
        }

        HashSet<string> cycles = new HashSet<string>();
        DFS(node, cycles);
    }

    Console.WriteLine($"Acyclic: Yes");
}
catch (InvalidOperationException)
{
    Console.WriteLine($"Acyclic: No");
}


void DFS(string node, HashSet<string> cycles)
{
    if (cycles.Contains(node))
    {
        throw new InvalidOperationException();
    }

    cycles.Add(node);
    visited.Add(node);

    foreach (var child in graph[node])
    {
        DFS(child, cycles);
    }
}