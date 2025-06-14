
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
        BFS(node, component);

        Console.WriteLine($"Connected component: {string.Join(" ", component)}");
    }
}

void BFS(int startNode, List<int> component)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(startNode);
    visited[startNode] = true;

    while (queue.Count > 0)
    {
        int currentNode = queue.Dequeue();
        component.Add(currentNode);

        foreach (var child in graph[currentNode])
        {
            if (!visited[child])
            {
                visited[child] = true;
                queue.Enqueue(child);
            }
        }
    }

}