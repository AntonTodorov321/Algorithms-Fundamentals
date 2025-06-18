using System.Text;

int nodes = int.Parse(Console.ReadLine());
int pairsCount = int.Parse(Console.ReadLine());

Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
StringBuilder sb = new StringBuilder();


for (int i = 0; i < nodes; i++)
{
    string[] nodeAndChildren = Console.ReadLine()
                                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

    int node = int.Parse(nodeAndChildren[0]);

    if (nodeAndChildren.Count() == 1)
    {
        graph[node] = new List<int>();
    }
    else
    {
        List<int> children = nodeAndChildren[1]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        graph[node] = children;
    }
}

for (int i = 0; i < pairsCount; i++)
{
    int[] pair = Console.ReadLine()
                    .Split("-")
                    .Select(int.Parse)
                    .ToArray();

    int start = pair[0];
    int destination = pair[1];

    int steps = BFS(start, destination);

    sb.AppendLine($"{{{start}, {destination}}} -> {steps}");
}

Console.WriteLine(sb.ToString());

int BFS(int start, int destination)
{
    HashSet<int> visited = new HashSet<int> { start };
    Queue<int> queue = new Queue<int>();
    Dictionary<int, int> parent = new Dictionary<int, int>();

    queue.Enqueue(start);
    parent[start] = -1;

    while (queue.Count > 0)
    {
        int node = queue.Dequeue();

        if (node == destination)
        {
            return GetSteps(parent, destination);
        }

        foreach (var child in graph[node])
        {
            if (!visited.Contains(child))
            {
                visited.Add(child);
                queue.Enqueue(child);

                parent[child] = node;
            }
        }
    }

    return -1;
}

int GetSteps(Dictionary<int, int> parent, int node)
{
    int steps = 0;

    while (node != -1)
    {
        steps++;
        node = parent[node];
    }

    return steps - 1;
}