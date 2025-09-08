namespace Guards
{
    using System;

    internal class Program
    {
        private static bool[] used;
        private static List<int>[] graph;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes + 1];
            used = new bool[nodes + 1];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                int[] edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int from = edge[0];
                int to = edge[1];

                graph[from].Add(to);
            }

            int start = int.Parse(Console.ReadLine());

            DFS(start);

            int[] unreachable = used
                                   .Select((value, index) => new { value, index })
                                   .Where(x => !x.value && x.index != 0)
                                   .Select(x => x.index)
                                   .ToArray();

            Console.WriteLine(string.Join(" ", unreachable));
        }
        private static void DFS(int node)
        {
            if (used[node])
            {
                return;
            }

            used[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}
