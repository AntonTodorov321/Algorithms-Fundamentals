
int n = int.Parse(Console.ReadLine());
int e = int.Parse(Console.ReadLine());

List<int>[] graph = new List<int>[n + 1];
int[] parent = new int[graph.Length];

Array.Fill(parent, -1);

for (int node = 0; node < graph.Length; node++)
{
    graph[node] = new List<int>();
}

for (int i = 0; i < e; i++)
{
    int[] elements = Console.ReadLine()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();

    int firstNode = elements[0];
    int secondNode = elements[1];

    graph[firstNode].Add(secondNode);
    graph[secondNode].Add(firstNode);
}

int start = int.Parse(Console.ReadLine());
int destination = int.Parse(Console.ReadLine());

BFS(start, destination);

void BFS(int node, int destination)
{
    Queue<int> queue = new Queue<int>();
    bool[] visited = new bool[graph.Length];

    visited[node] = true;
    queue.Enqueue(node);

    while (queue.Count > 0)
    {
        int current = queue.Dequeue();

        if (current == destination)
        {
            Stack<int> path = new Stack<int>();
            GeneratePath(path, destination);

            Console.WriteLine($"Shortest path length is: {path.Count - 1}");
            Console.WriteLine(string.Join(" ", path));

            break;
        }

        foreach (var child in graph[current])
        {
            if (!visited[child])
            {
                parent[child] = current;
                queue.Enqueue(child);
                visited[child] = true;
            }
        }
    }
}

void GeneratePath(Stack<int> path, int destination)
{
    int node = destination;

    while (node != -1)
    {
        path.Push(node);
        node = parent[node];
    }
}