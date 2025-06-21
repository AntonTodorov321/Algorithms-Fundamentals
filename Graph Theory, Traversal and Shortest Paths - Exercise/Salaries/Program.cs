
int n = int.Parse(Console.ReadLine());

List<int>[] graph = new List<int>[n];
Dictionary<int, int> visited = new Dictionary<int, int>();

for (int node = 0; node < n; node++)
{
    graph[node] = new List<int>();
}

for (int node = 0; node < n; node++)
{
    string children = Console.ReadLine();

    for (int child = 0; child < children.Length; child++)
    {
        if (children[child] == 'Y')
        {
            graph[node].Add(child);
        }
    }
}

int salary = 0;

for (int node = 0; node < graph.Length; node++)
{
    salary += DFS(node);
}

Console.WriteLine(salary);

int DFS(int node)
{
    if (visited.ContainsKey(node))
    {
        return visited[node];
    }

    int salary = 0;

    if (graph[node].Count == 0)
    {
        salary = 1;
    }
    else
    {
        foreach (var child in graph[node])
        {
            salary += DFS(child);
        }
    }

    visited[node] = salary;
    return salary;
}