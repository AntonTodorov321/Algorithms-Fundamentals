
class Edge
{
    public Edge(int first, int second)
    {
        First = first;
        Second = second;
    }

    public int First { get; set; }
    public int Second { get; set; }

    public override string ToString()
    {
        return $"{First} {Second}";
    }
}

public class Program
{
    private static List<int>[] graph;
    private static List<Edge> edges;
    private static bool[] visited;

    public static void Main()
    {
        int nodesCount = int.Parse(Console.ReadLine());
        int edgesCount = int.Parse(Console.ReadLine());

        graph = new List<int>[nodesCount];
        edges = new List<Edge>();

        for (int node = 0; node < nodesCount; node++)
        {
            graph[node] = new List<int>();
        }

        for (int i = 0; i < edgesCount; i++)
        {
            int[] edgeData = Console.ReadLine()
                                .Split(" - ")
                                .Select(int.Parse)
                                .ToArray();

            int firstNode = edgeData[0];
            int secondNode = edgeData[1];

            graph[firstNode].Add(secondNode);
            graph[secondNode].Add(firstNode);
            edges.Add(new Edge(firstNode, secondNode));
        }

        Console.WriteLine($"Important streets:");

        foreach (var edge in edges)
        {
            int firstNode = edge.First;
            int secondNode = edge.Second;

            graph[firstNode].Remove(secondNode);
            graph[secondNode].Remove(firstNode);

            visited = new bool[nodesCount];

            DFS(0);

            if (visited.Contains(false))
            {
                Edge newEdge = 
                    new Edge(Math.Min(firstNode, secondNode), Math.Max(firstNode, secondNode));

                Console.WriteLine(newEdge);
            }

            graph[firstNode].Add(secondNode);
            graph[secondNode].Add(firstNode);
        }
    }

    private static void DFS(int node)
    {
        if (visited[node])
        {
            return;
        }

        visited[node] = true;

        foreach (var child in graph[node])
        {
            DFS(child);
        }
    }
}