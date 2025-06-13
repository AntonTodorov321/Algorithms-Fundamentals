
using System.Runtime.CompilerServices;

int n = int.Parse(Console.ReadLine());
List<int>[] graph = new List<int>[n];
bool[] visited = new bool[n];

for (int node = 0; node < n; node++)
{
    string input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
    {
        graph[node] = new List<int>();
        continue;
    }

    List<int> children = input
                   .Split(" ")
                   .Select(int.Parse)
                   .ToList();

    graph[node] = children;
}

for (int node = 0; node < n; node++)
{
    if (!visited[node])
    {
        List<int> component = new List<int>();
        DFS(node, component);

        Console.WriteLine($"Connected component: {string.Join(" ", component)}");
    }
}

void DFS(int node, List<int> component)
{
    if (visited[node])
    {
        return;
    }

    visited[node] = true;

    foreach (var child in graph[node])
    {
        DFS(child, component);
    }

    component.Add(node);
}