class Edge
{
    public Edge(string first, string second)
    {
        First = first;
        Second = second;
    }

    public string First { get; set; }
    public string Second { get; set; }

    public override string ToString()
    {
        return $"{First} - {Second}";
    }
}

public class Program
{
    static Dictionary<string, List<string>> graph;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        graph = new Dictionary<string, List<string>>();
        List<Edge> removedEdges = new List<Edge>();
        List<Edge> edges = new List<Edge>();

        for (int i = 0; i < n; i++)
        {
            string[] nodeAndChildren = Console.ReadLine().Split(" -> ");

            string node = nodeAndChildren[0];
            List<string> children = nodeAndChildren[1].Split(" ").ToList();

            graph[node] = children;

            foreach (var child in children)
            {
                edges.Add(new Edge(node, child));
            }
        }

        edges = edges
               .OrderBy(e => e.First)
               .ThenBy(e => e.Second)
               .ToList();

        foreach (var edge in edges)
        {
            string first = edge.First;
            string second = edge.Second;

            bool canRemove = graph[first].Remove(second) && graph[second].Remove(first);

            if (!canRemove)
            {
                continue;
            }

            if (BFS(first, second))
            {
                removedEdges.Add(edge);
            }
            else
            {
                graph[first].Add(second);
                graph[second].Add(first);
            }
        }

        Console.WriteLine($"Edges to remove: {removedEdges.Count}");

        foreach (var edge in removedEdges)
        {
            Console.WriteLine(edge);
        }
    }

    static bool BFS(string start, string destination)
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(start);

        HashSet<string> visited = new HashSet<string> { start };

        while (queue.Count > 0)
        {
            string node = queue.Dequeue();

            if (node == destination)
            {
                return true;
            }

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child))
                {
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }
        }

        return false;
    }
}