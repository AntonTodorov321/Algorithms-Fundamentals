namespace Paths
{
    using System;

    internal class Program
    {
        private static List<int>[] graph;
        private static List<int> path;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            path = new List<int>();

            ReadGraph(nodes);

            for (int node = 0; node < nodes - 1; node++)
            {
                DFS(node);
            }
        }

        private static void DFS(int node)
        {
            path.Add(node);

            if (node == graph.Length - 1)
            {
                Console.WriteLine(string.Join(" ", path));
                path.Remove(node);
                return;
            }

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            path.Remove(node);
        }

        private static void ReadGraph(int nodes)
        {
            for (int node = 0; node < nodes; node++)
            {
                graph[node] = new List<int>();

                string childrenData = Console.ReadLine();

                if (string.IsNullOrEmpty(childrenData))
                {
                    continue;
                }

                List<int> children = childrenData
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

                graph[node] = children;

            }
        }
    }
}
