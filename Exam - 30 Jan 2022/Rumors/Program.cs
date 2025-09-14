namespace Rumors
{
    using System;

    internal class Program
    {
        private static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int connections = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 1; i <= people; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < connections; i++)
            {
                string[] elements = Console.ReadLine().Split();

                int from = int.Parse(elements[0]);
                int to = int.Parse(elements[1]);

                graph[from].Add(to);
                graph[to].Add(from);
            }

            int startNode = int.Parse(Console.ReadLine());
            int[] times = BFS(startNode, people);

            foreach (var node in graph.Keys)
            {
                if (node != startNode && times[node] != -1)
                {
                    Console.WriteLine($"{startNode} -> {node} ({times[node]})");
                }
            }
        }

        private static int[] BFS(int startNode, int people)
        {
            int[] times = new int[people + 1];

            for (int i = 0; i < times.Length; i++)
            {
                times[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);

            times[startNode] = 0;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                foreach (var child in graph[current])
                {
                    if (times[child] == -1)
                    {
                        times[child] = times[current] + 1;

                        queue.Enqueue(child);
                    }
                }
            }

            return times;
        }
    }
}
